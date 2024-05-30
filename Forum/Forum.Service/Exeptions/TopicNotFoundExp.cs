using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Exeptions
{
    public class TopicNotFoundExp : Exception
    {
        public TopicNotFoundExp() : base("Topic not found!") { }
    }
}
