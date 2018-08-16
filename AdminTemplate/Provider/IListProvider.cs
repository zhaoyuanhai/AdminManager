using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace AdminTemplate.Provider
{
    public interface IListProvider
    {
        IEnumerable<ListItem> GetListItems(string listName);
    }
}
