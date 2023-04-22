using MyCredVault.Common;
using MyCredVault.Helpers;
using MyCredVault.ViewModels;
using System.ComponentModel;
using System.DirectoryServices.AccountManagement;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace MyCredVault
{
    public partial class FrmMain : Form
    {
        #region Variables

        private List<CredentialVault> CredentialVaults { get; set; } = new List<CredentialVault>();

        private string? SelectedId { get; set; }

        private bool IsProcessing
        {
            set
            {
                if (value)
                {
                    btnSave.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;
                }
                else
                {
                    btnSave.Enabled = true;
                    this.Cursor = Cursors.Default;
                    //txtKey.Focus();
                }
            }
        }

        private string InputKey
        {
            get
            {
                return txtKey.Text.Trim();
            }
            set
            {
                txtKey.Text = value;
            }
        }

        private string InputValue
        {
            get
            {
                return txtValue.Text.Trim();
            }
            set
            {
                txtValue.Text = value;
            }
        }

        private string UserId
        {
            get
            {
                return System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            }
        }

        private string SearchText
        {
            get
            {
                return txtSearch.Text;
            }
        }

        #endregion

        #region Constructor

        public FrmMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void FrmMain_Load(object sender, EventArgs e)
        {
            RunAction(() =>
            {
                if (Authenticate())
                {
                    Initialize();
                    BindData();
                }
                else
                {
                    MessageBox.Show("Authentication failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RunAction(() =>
            {
                IsProcessing = true;
                ValidateInputs();

                var environmentVariableName = string.IsNullOrEmpty(SelectedId) ? GetId() : SelectedId;
                var credential = new CredentialVault
                {
                    Id = environmentVariableName,
                    Key = InputKey,
                    Value = InputValue
                };

                // Save environment variable
                var json = JsonSerializer.Serialize<CredentialVault>(credential);
                var cipherText = EncryptDecryptHelper.Encrypt(UserId, json);
                Environment.SetEnvironmentVariable(environmentVariableName, cipherText, EnvironmentVariableTarget.User);

                // Update list
                if (SelectedId == null)
                {
                    CredentialVaults.Add(credential);
                }
                else
                {
                    var local = CredentialVaults.FirstOrDefault(item => item.Id == SelectedId);
                    local.Key = credential.Key;
                    local.Value = credential.Value;
                }

                IsProcessing = false;
                MessageBox.Show("Record saved successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BindData();
                ResetForm();
            });
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void dgvItems_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RunAction(() =>
            {
                var index = e.RowIndex;
                var id = dgvItems.Rows[index].Cells["Id"].Value;
                if (id != null)
                {
                    SelectedId = id.ToString();
                    InputKey = dgvItems.Rows[index].Cells["Key"].Value?.ToString();
                    InputValue = dgvItems.Rows[index].Cells["Value"].Value?.ToString();
                }
            });
        }

        private void dgvItems_KeyDown(object sender, KeyEventArgs e)
        {
            RunAction(() =>
            {
                if (e.KeyData == Keys.Delete)
                {
                    if (MessageBox.Show(
                        "Are you sure you want to delete this record?",
                        "Message",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var index = dgvItems.CurrentRow.Index;
                        var id = dgvItems.Rows[index].Cells["Id"].Value;
                        if (id != null)
                        {
                            Environment.SetEnvironmentVariable(id.ToString(), null, EnvironmentVariableTarget.User);

                            CredentialVaults.RemoveAll(item => item.Id == id.ToString());
                            BindData();
                        }
                    }
                }
            });
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RunAction(() =>
            {
                LoadData();
                BindData();
            });
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RunAction(() =>
            {
                LoadData();
                BindData();
            });
        }

        #endregion

        #region Private Methods

        private void RunAction(Action action)
        {
            try
            {
                action();
            }
            catch (AppException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Message",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show(
                    "An error occurred while processing.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                IsProcessing = false;
            }
        }

        private void Initialize()
        {
            LoadData();
        }

        private void LoadData()
        {
            var allVariables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User);
            var variables = allVariables.Keys
                .Cast<string>()
                .Where(item => item.StartsWith(ConstHelper.ENVIRONMENT_VARIABLE_NAME));

            if (variables.Any())
            {
                CredentialVaults = variables
                    .Select(item =>
                    {
                        var encryptedValue = allVariables[item]?.ToString();
                        // decrypt
                        var json = EncryptDecryptHelper.Decrypt(UserId, encryptedValue);

                        // deserialize
                        var credential = JsonSerializer.Deserialize<CredentialVault>(json);

                        return credential;
                    })
                    .Where(item => string.IsNullOrEmpty(SearchText) || item.Key.ToUpper().Contains(SearchText.ToUpper()))
                    .ToList();
            }
        }

        private void BindData()
        {
            if (CredentialVaults != null)
            {
                var bindingList = new BindingList<CredentialVault>(CredentialVaults.OrderBy(item => item.Key).ToList());
                var source = new BindingSource(bindingList, null);
                dgvItems.DataSource = source;
                dgvItems.Refresh();
            }
        }

        private void ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtKey.Text))
            {
                throw new AppException("Enter the credential name.");
            }

            if (string.IsNullOrEmpty(txtValue.Text))
            {
                throw new AppException("Enter the value.");
            }
        }

        private void ResetForm()
        {
            InputKey = null;
            InputValue = null;
            txtKey.Focus();
            SelectedId = null;
        }

        private string GenerateUniqueId()
        {
            long ticks = DateTime.Now.Ticks;
            byte[] bytes = BitConverter.GetBytes(ticks);
            string id = Convert.ToBase64String(bytes)
                .Replace("/", "")
                .Replace("+", "")
                .Replace("=", "");

            return id;
        }

        private string GetId()
        {
            return $"{ConstHelper.ENVIRONMENT_VARIABLE_NAME}_{GenerateUniqueId()}";
        }

        private bool Authenticate()
        {
            CREDUI_INFO credui = new CREDUI_INFO();
            credui.pszCaptionText = "Sign in with local account";
            credui.cbSize = Marshal.SizeOf(credui);
            uint authPackage = 0;
            IntPtr outCredBuffer = new IntPtr();
            uint outCredSize;
            bool save = false;
            int result = Authentication.CredUIPromptForWindowsCredentials(ref credui, 0, ref authPackage, IntPtr.Zero, 0, out outCredBuffer, out outCredSize, ref save, 1 /* Generic */);

            var usernameBuf = new StringBuilder(100);
            var passwordBuf = new StringBuilder(100);
            var domainBuf = new StringBuilder(100);

            int maxUserName = 100;
            int maxDomain = 100;
            int maxPassword = 100;
            if (result == 0)
            {
                if (Authentication.CredUnPackAuthenticationBuffer(0, outCredBuffer, outCredSize, usernameBuf, ref maxUserName, domainBuf, ref maxDomain, passwordBuf, ref maxPassword))
                {
                    //clear the memory allocated by CredUIPromptForWindowsCredentials
                    Authentication.CoTaskMemFree(outCredBuffer);

                    using (var principalContext = new PrincipalContext(ContextType.Machine, null, null, usernameBuf.ToString(), passwordBuf.ToString()))
                    {
                        // validate the credentials
                        return principalContext.ValidateCredentials(usernameBuf.ToString(), passwordBuf.ToString());
                    }
                }
            }

            return false;
        }

        #endregion
    }
}
