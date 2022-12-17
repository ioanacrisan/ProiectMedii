using Microsoft.AspNetCore.Mvc.RazorPages;
using ProiectMedii.Data;

namespace ProiectMedii.Models
{
    public class ServiceCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(ProiectMediiContext context,
        Service service)
        {
            var allCategories = context.Category;
            var serviceCategories = new HashSet<int>(
            service.ServiceCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = serviceCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateServiceCategories(ProiectMediiContext context,
        string[] selectedCategories, Service serviceToUpdate)
        {
            if (selectedCategories == null)
            {
                serviceToUpdate.ServiceCategories = new List<ServiceCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var serviceCategories = new HashSet<int>
            (serviceToUpdate.ServiceCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!serviceCategories.Contains(cat.ID))
                    {
                        serviceToUpdate.ServiceCategories.Add(
                        new ServiceCategory
                        {
                            ServiceID = serviceToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (serviceCategories.Contains(cat.ID))
                    {
                        ServiceCategory courseToRemove
                        = serviceToUpdate
                        .ServiceCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
