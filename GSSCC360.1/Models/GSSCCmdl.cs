using GSSCC360._1.EsxtensionsMethods;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml.Linq;

using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;

namespace GSSCC360._1.Models
{
    //public class GSSCCmdlDatabaseInitializer : DropCreateDatabaseAlways<GSSCC360_devEntities>
    //public class GSSCCmdlDatabaseInitializer : CreateDatabaseIfNotExists<GSSCC360_devEntities>
    public class GSSCCmdlDatabaseInitializer : DropCreateDatabaseIfModelChanges<GSSCC360_devEntities>
    {
        public override void InitializeDatabase(GSSCC360_devEntities context)
        {
            ((IObjectContextAdapter) context).ObjectContext.ContextOptions.ProxyCreationEnabled = false;

            // Wipe Regions
            context.Regions.RemoveRange(context.Regions);
            //;
            //context.Database.ExecuteSqlCommand(String.Format("TRUNCATE TABLE {0}", GetTableName(typeof(Region), context)));

            //context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);


            Seed(context);

        }

        protected override void Seed(GSSCC360_devEntities context)
        {
            string resourceName; 
            var assembly = Assembly.GetExecutingAssembly();

            #region Breeds
            resourceName = "GSSCC360._1.App_Data.Breeds.xml";
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    var xml = XDocument.Load(stream);

                    var breeds = xml.Element("Root")
                                    .Elements("Breed")
                                    .Select(x => new lutBreed
                                    {
                                        Name = (string)x.Attribute("Name"),
                                        Acronym = (string)x.Attribute("Acronym"),
                                    }).ToArray();
                    context.lutBreeds.AddRange(breeds);

                    context.SaveChanges();
                }

            }
            #endregion // Breeds

            #region Regions
            resourceName = "GSSCC360._1.App_Data.Regions.xml";
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    var xml = XDocument.Load(stream);

                    var regions = xml.Element("Root")
                                    .Elements("Region")
                                    .Select(x => new Region
                                    {
                                        Name = (string)x.Attribute("Name"),
                                    }).ToArray();
                    context.Regions.AddRange(regions);

                    context.SaveChanges();
                }

            }
            #endregion // Regions

            #region People/Members
            context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            resourceName = "GSSCC360._1.App_Data.GSSCC Membership List - 28 January 2019 for Darin.xml";
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    var xml = XDocument.Load(stream);
                    foreach (var elt in xml.Element("data-set").Elements("record"))
                    {
                        var person = new Person
                        {
                            Firstname = (string)elt.Element("FirstName"),
                            LastName = (string)elt.Element("LastName"),
                            Address1 = (string)elt.Element("Address1"),
                            City = (string)elt.Element("City"),
                            Country = "",
                            Province = (string)elt.Element("Province"),
                            EMail = (string)elt.Element("EMail"),
                        };
                        context.People.Add(person);
                        //context.SaveChanges();              // generates unique id

                        var member = new Member
                        {
                            GSSCCNumber = (string)elt.Element("Number"),
                        };

                        context.Members.Add(member);
                        member.Person = person;             // uses person's unique id
                        //context.SaveChanges();
                    }
                    context.SaveChanges();
                }

            }
            #endregion // Members

            #region People
            //resourceName = "GSSCC360._1.App_Data.GSSCC Membership List - 28 January 2019 for Darin.xml";
            //using (var stream = assembly.GetManifestResourceStream(resourceName))
            //{
            //    if (stream != null)
            //    {
            //        var xml = XDocument.Load(stream);

            //        foreach (var elt in xml.Element("data-set").Elements("record"))
            //        {

            //        }
                                    
            //        var people = xml.Element("data-set")
            //                        .Elements("record")
            //                        .Select(x => new Person
            //                        {
            //                            Firstname = (string)x.Element("FirstName"),
            //                            LastName = (string)x.Element("LastName"),
            //                            Address1 = (string)x.Element("Address1"),
            //                            City = (string)x.Element("City"),
            //                            Country = "",
            //                            Province = (string)x.Element("Province"),
            //                            EMail = (string)x.Element("EMail"),
            //                        }).ToArray();


            //        context.People.AddRange(people);

            //        context.SaveChanges();
            //    }

            //}
            #endregion // People


            base.Seed(context);

            #region trivia
            /*
            base.Seed(context);

            var questions = new List<TriviaQuestion>();

            questions.Add(new TriviaQuestion
            {
                Title = "When was .NET first released?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "2000", IsCorrect = false },
                    new TriviaOption { Title = "2001", IsCorrect = false },
                    new TriviaOption { Title = "2002", IsCorrect = true },
                    new TriviaOption { Title = "2003", IsCorrect = false }
                }).ToList()
            });


            questions.ForEach(a => context.TriviaQuestions.Add(a));

            context.SaveChanges();
            */
            #endregion // trivia
        }

        public static string GetTableName(Type type, DbContext context)
        {
            var metadata = ((IObjectContextAdapter)context).ObjectContext.MetadataWorkspace;

            // Get the part of the model that contains info about the actual CLR types
            var objectItemCollection = ((ObjectItemCollection)metadata.GetItemCollection(DataSpace.OSpace));

            // Get the entity type from the model that maps to the CLR type
            var entityType = metadata
                    .GetItems<EntityType>(DataSpace.OSpace)
                    .Single(e => objectItemCollection.GetClrType(e) == type);

            // Get the entity set that uses this entity type
            var entitySet = metadata
                .GetItems<EntityContainer>(DataSpace.CSpace)
                .Single()
                .EntitySets
                .Single(s => s.ElementType.Name == entityType.Name);

            // Find the mapping between conceptual and storage model for this entity set
            var mapping = metadata.GetItems<EntityContainerMapping>(DataSpace.CSSpace)
                    .Single()
                    .EntitySetMappings
                    .Single(s => s.EntitySet == entitySet);

            // Find the storage entity set (table) that the entity is mapped
            var table = mapping
                .EntityTypeMappings.Single()
                .Fragments.Single()
                .StoreEntitySet;

            // Return the table name from the storage entity set
            return (string)table.MetadataProperties["Table"].Value ?? table.Name;
        }
    }

}
