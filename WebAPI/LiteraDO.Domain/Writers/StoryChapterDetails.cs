using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteraDO.Domain.Writers
{
    public class StoryChapterDetails : BaseEntity
    {
        public int StoryChapterId { get; set; }
        public string Name { get; set; }
        public string Line { get; set; }

        public StoryChapter StoryChapter { get; set; }
    }
}
