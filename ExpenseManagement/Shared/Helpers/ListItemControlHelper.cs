using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Shared.Helpers
{
    public class ListItemControlHelper
    {
        /// <summary>
        /// Monta uma lista de itens
        /// </summary>
        /// <param name="itens"></param>
        /// <returns></returns>
        public static List<ItemControl> GetListItensControl(Dictionary<string, string> itens)
        {
            var list = new List<ItemControl>();
            foreach (var item in itens)
            {
                list.Add(new ItemControl() { Id = item.Key, Value = item.Value });
            }
            return list;
        }

        /// <summary>
        /// Define o item selecionado
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="id"></param>
        public static void SetItemSelected(List<ItemControl> lst, string id)
        {
            if (!string.IsNullOrEmpty(id) && lst != null && lst.Any())
            {
                lst.ForEach(item => item.Selected = false);
                var item = lst.FirstOrDefault(x => x.Id == id);
                if(item != null)
                    item.Selected = true;
            }
        }
    }

    public class ItemControl
    {
        /// <summary>
        /// Representa o id do item
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Indica o valor
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Indica que o item foi selecionado
        /// </summary>
        public bool Selected { get; set; }
        /// <summary>
        /// Icone
        /// </summary>
        public string Icon { get; set; }
    }
}
