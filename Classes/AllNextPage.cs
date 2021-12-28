using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Classes
{
    class AllNextPage
    {
        public delegate void NextPage(object sender, EventArgs e);
        public event NextPage Page;
        public EventArgs e=null;
    }
}
