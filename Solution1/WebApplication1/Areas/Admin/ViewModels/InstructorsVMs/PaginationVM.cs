using System.Collections;

namespace WebApplication1.Areas.Admin.ViewModels.InstructorsVMs
{
    public class PaginationVM<T> where T : IEnumerable
    {

        public int currentpage { get; set; }
        public int lastpage { get; set; }
        public int totalcount { get; set; }
        public T items { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrev { get; set; }

        public PaginationVM(int currentpage, int lastpage, int totalcount, T items)
        {
            if (currentpage <= 0) throw new ArgumentException();
            this.currentpage = currentpage;
            this.lastpage = lastpage;
            this.totalcount = totalcount;
            this.items = items;
            
            if (currentpage <= lastpage)
            {
                if (currentpage == 1)
                {
                    HasPrev = false;
                }
                else
                {
                    HasPrev = true;
                }
                if(currentpage== lastpage)
                {
                    HasNext = false;
                }
                else
                {
                    HasNext= true;
                }
            }

        }
    }
}
