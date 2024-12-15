using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.DAO
{
    public class CartDAO : DAO<CartDAO>
    {
        #region Add new cart
        public async Task<(bool rs, string msg)> Add(Cart cart)
        {
            try
            {
                Cart? c = await Instance.DB.Carts.Where(c => c.UserId == cart.UserId && c.ProductId == c.ProductId).FirstOrDefaultAsync();
                if (c != null)
                {
                    Instance.DB.Entry(c).CurrentValues.SetValues(c.Quantity += cart.Quantity);
                    await Instance.DB.SaveChangesAsync();

                    return (true, "Update quantity!");
                }

                Instance.DB.Add(cart);
                await Instance.DB.SaveChangesAsync();
                return (true, "Done!");
            }
            catch (Exception)
            {
                return (false, new Exception().Message);
            }
        }
        #endregion

        #region Update cart
        public async Task<(bool rs, string msg)> Update(Cart cart)
        {
            try
            {
                var c = await Instance.DB.Carts.Where(c => c.UserId == cart.UserId && c.ProductId == cart.ProductId).FirstOrDefaultAsync();
                if (c == null) return (false, "Item does not found!");

                Instance.DB.Entry(c).CurrentValues.SetValues(cart.Quantity);
                await Instance.DB.SaveChangesAsync();
                return (true, "Done!");
            }
            catch (Exception)
            {
                return (false, new Exception().Message);
            }
        }
        #endregion

        #region Delete cart
        public async Task<(bool rs, string msg)> Delete(string cartID)
        {
            try
            {
                var c = await Instance.DB.Carts.FirstAsync(c => c.Id == cartID);
                if (c == null) return (false, "Not found!");

                Instance.DB.Carts.Remove(c);
                await Instance.DB.SaveChangesAsync();

                return (true, "Done!");
            }
            catch (Exception)
            {
                return (false, new Exception().Message);
            }
        }
        #endregion

        #region Find cart
        public async Task<Cart?> Find(string cartID)
        {
            try
            {
                var c = await Instance.DB.Carts.FindAsync(cartID);

                return c;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region List cart
        public async Task<IEnumerable<Cart>> ToList()
        {
            try
            {
                IEnumerable<Cart> list = await Instance.DB.Carts.ToListAsync();
                return list;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        #endregion
    }
}
