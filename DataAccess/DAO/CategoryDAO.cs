using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.DAO
{
    public class CategoryDAO : DAO<CategoryDAO>
    {
        #region Find category
        public async Task<Category?> Find(string categoryID)
        {
            try
            {
                return await Instance.DB.Categories.FindAsync(categoryID);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        #endregion

        #region Add new category
        public async Task<(bool rs, string msg)> Add(Category category)
        {
            try
            {
                var cate = await Find(category.Id);
                var item = await Instance.DB.Categories.Where(c => c.Name.ToLower() == category.Name.ToLower()).FirstOrDefaultAsync();
                if (cate != null || item != null) return (false, "Category has been exist!");

                Instance.DB.Categories.Add(category);
                await Instance.DB.SaveChangesAsync();

                return (true, "Done!");
            }
            catch (Exception)
            {
                return (false, new Exception().Message);
            }
        }
        #endregion

        #region Update category
        public async Task<(bool rs, string msg)> Update(Category category)
        {
            try
            {
                var cate = await Instance.DB.Categories.FindAsync(category.Id);
                if (cate == null) return (false, "Not found!");

                Instance.DB.Entry(cate).CurrentValues.SetValues(category);
                await Instance.DB.SaveChangesAsync();

                return (true, "Done!");
            }
            catch (Exception)
            {
                return (false, new Exception().Message);
            }
        }
        #endregion

        #region Delete category
        public async Task<(bool rs, string msg)> Delete(string categoryID)
        {
            try
            {
                var cate = await Instance.DB.Categories.FindAsync(categoryID);
                if (cate == null) return (false, "Does not exist");

                Instance.DB.Categories.Remove(cate);
                await Instance.DB.SaveChangesAsync();

                return (true, "Done!");
            }
            catch (Exception)
            {
                return (false, new Exception().Message);
            }
        }
        #endregion

        #region List category
        public async Task<IEnumerable<Category>> ToList()
        {
            try
            {
                return await Instance.DB.Categories.ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        #endregion
    }
}
