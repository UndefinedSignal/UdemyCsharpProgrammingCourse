using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourseChapter1
{
    public class BankTerminal
    {
        protected string id;

        public BankTerminal(string id)
        {
            this.id = id;
        }

        public virtual void Connect()
        {
            Console.WriteLine("General Connecting Protocol...");
        }
    }

    public class ModelXTeminal : BankTerminal
    {
        public ModelXTeminal(string id) : base(id)
        {
        }
        public override void Connect()
        {
            base.Connect();
            Console.WriteLine("Additional actions for Model X");
        }
    }

    public class ModelYTeminal : BankTerminal
    {
        public ModelYTeminal(string id) : base(id)
        {
        }
        public override void Connect()
        {
            Console.WriteLine("Additional for Model Y");
        }
    }
}
