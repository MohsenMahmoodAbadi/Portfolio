using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageRepository :  IDisposable
    {
        IEnumerable<Page> GetAllPages();
        Page GetPageById(int pageId);
        bool InsertPage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(Page page);
        bool DeletePage(int pageId);
        void Save();

        IEnumerable<Page> TopNews(int take = 4);
        IEnumerable<Page> PagesInSlider();
        IEnumerable<Page> LatestNews(int take = 4);

        IEnumerable<Page> ShowPageByGroupId(int groupId);
        IEnumerable<Page> SearchPage(string search);
    }
}
