using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using db_TO.model;

namespace db_TO.DAL
{
    class TOInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TOContext>
    {
        protected override void Seed(TOContext context)
        {
            var marks = new List<Mark>()
            {
                new Mark {MarkName = "BMW", Models = new List<Model>()
                    { new Model() {ModelName = "X3" }, new Model() {ModelName = "X5"} } },

                new Mark {MarkName = "Lada", Models = new List<Model>()
                    { new Model() {ModelName = "Granta" }, new Model() {ModelName = "Vesta"} }},

                new Mark {MarkName = "Ford", Models = new List<Model>()
                    { new Model() {ModelName = "Bronco" }, new Model() {ModelName = "F150"} }},

                new Mark {MarkName = "Lancia", Models = new List<Model>()
                    { new Model() {ModelName = "Delta" }, new Model() {ModelName = "Prisma"} }},
            };
            marks.ForEach(s => context.MarkDb.Add(s));
            base.Seed(context);
        }
    }
}
