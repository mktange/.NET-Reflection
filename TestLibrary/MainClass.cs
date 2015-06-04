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
        TransferClass someObject;

        public MainClass() {
            this.someString = "Here is a simple string";

            this.someObject = new TransferClass();
            
            this.someObject.blah = 1;
            this.someObject.pop = 1337;
            this.someObject.Test = "This is a test";
            this.someObject.Hmm = "Woop";
        }


        public TransferClass GetSomeObject()
        {
            return this.someObject;
        }

        public string GetSomeString()
        {
            return this.someString;
        }

        public Tuple<string, TransferClass> GetSomeTuple()
        {
            return new Tuple<string, TransferClass>(this.someString, this.someObject);
        }
    }
}
