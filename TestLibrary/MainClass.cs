using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class TransferClass
    {
        public string Test { get; set; }
        public string Hmm { get; set; }
        public int blah { get; set; }
        public int pop { get; set; }

        public TransferClass()
        {
            this.Test = "TEST";
        }
    }


    public class MainClass
    {
        string someString;
        TransferClass someClass;

        public MainClass() {
            this.someString = "Here is a simple string";

            this.someClass = new TransferClass();
            
            this.someClass.blah = 1;
            this.someClass.pop = 1337;
            this.someClass.Test = "This is a test";
            this.someClass.Hmm = "Woop";
        }


        public TransferClass GetSomeObject()
        {
            return this.someClass;
        }

        public string GetSomeString()
        {
            return this.someString;
        }
    }
}
