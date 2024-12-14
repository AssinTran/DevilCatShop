using Models;
using BCrypt.Net;
using System.Text.Json;

namespace DataAccess.DAO
{
    public class AccountDAO : DAO<AccountDAO>
    {
        #region Sign in
        public async Task<(bool rs, string msg)> SignIn(string phonenumber, string password)
        {
            try
            {
                Account? acc = await Instance.DB.Accounts.FindAsync(phonenumber);
                if (acc == null || acc.Status == false) return (false, "Account does not exist!");
                if (BCrypt.Net.BCrypt.Verify(password, acc.Password)) return (false, "Phone number or password incorrect!");

                return (true, phonenumber);

            }
            catch (Exception)
            {
                return (false, new Exception().Message);
            }
        }
        #endregion

        #region Sign up
        public async Task<(bool rs, string msg)> SignUp(Account account)
        {
            try
            {
                if (account == null) return (false, "Invalid value!");

                var acc = await Instance.DB.Accounts.FindAsync(account.Phonenumber);
                if (acc != null) return (false, "Account already exist!");

                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
                Instance.DB.Accounts.Add(account);
                await Instance.DB.SaveChangesAsync();
                return (true, "done");
            }
            catch (Exception)
            {
                return (false, new Exception().Message);
            }
        }
        #endregion

        #region Change password
        public async Task<(bool rs, string msg)> ChangePassword(Account account)
        {
            try
            {
                Account? acc = await Instance.DB.Accounts.FindAsync(account.Phonenumber);
                if (acc == null) return (false, "Not found!");

                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
                Instance.DB.Entry(acc).CurrentValues.SetValues(account);
                await Instance.DB.SaveChangesAsync();

                return (true, account.Phonenumber);
            }
            catch (Exception)
            {
                return (false, new Exception().Message);
            }
        }
        #endregion

        #region Ban Account
        public async Task<(bool rs, string msg)> BanAccount(string phonenumber)
        {
            try
            {
                var acc = await Instance.DB.Accounts.FindAsync(phonenumber);
                if (acc == null) return (false, "Not found!");

                Instance.DB.Entry(acc).CurrentValues.SetValues(acc.Status = false);
                await Instance.DB.SaveChangesAsync();

                return (true, "Done!");
            }
            catch (Exception)
            {
                return (false, new Exception().Message);
            }
        }
        #endregion

        #region Active Account
        public async Task<(bool rs, string msg)> ActiveAccount(string phonenumber)
        {
            try
            {
                var acc = await Instance.DB.Accounts.FindAsync(phonenumber);
                if (acc == null || acc.Status == false) return (false, "Not found!");

                if (acc.Active) return (true, "Account already actived!");

                Instance.DB.Entry(acc).CurrentValues.SetValues(acc.Active = true);
                await Instance.DB.SaveChangesAsync();

                return (true, "Actived!");
            }
            catch (Exception)
            {
                return (false, new Exception().Message);
            }
        }
        #endregion
    }
}
