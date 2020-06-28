using EFSQLite.Models;
using System;
using System.Threading.Tasks;

namespace EFSQLite
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                context.Add(new ObjectModel
                {
                    Name = "ObjectModelName",
                    PreviewImage = "ObjectModelPreviewImage",
                    TagName = "ObjectModelTagName",
                    TypeModel = new ObjectTypeModel
                    {
                        Name = "ObjectTypeModelName",
                        PreviewImage = "ObjectTypeModelPreviewImage",
                        TagName = "ObjectTypeModelTagName"
                    }
                });

                await context.SaveChangesAsync();

                var results = context.ObjectModels;
            }

            Console.ReadKey();
        }
    }
}
