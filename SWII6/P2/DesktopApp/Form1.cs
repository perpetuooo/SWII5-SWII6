using System;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
        private readonly ApiClient _apiClient;

        public Form1()
        {
            InitializeComponent();
            _apiClient = new ApiClient();
            ConfigureInitialState();
        }

        private void ConfigureInitialState()
        {
            cmbStatus.Items.AddRange(new[] { "Ativo", "Inativo" });
            cmbStatus.SelectedIndex = 0;

            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.ReadOnly = true;

            LoadUsers();
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtSenha.Clear();
            cmbStatus.SelectedIndex = 0;
            dgvUsuarios.ClearSelection();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O nome é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("A senha é obrigatória.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenha.Focus();
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Selecione um status.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return false;
            }

            return true;
        }

        private async void LoadUsers()
        {
            try
            {
                UseWaitCursor = true;
                var users = await _apiClient.GetUsersAsync();
                dgvUsuarios.DataSource = users;
                AjustarColunas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar usuários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UseWaitCursor = false;
            }
        }

        private void AjustarColunas()
        {
            if (dgvUsuarios.Columns.Contains("Senha"))
                dgvUsuarios.Columns["Senha"].Visible = false;

            foreach (DataGridViewColumn column in dgvUsuarios.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private async void btnLoadUsers_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                UseWaitCursor = true;
                var user = new Usuario
                {
                    Nome = txtNome.Text.Trim(),
                    Senha = txtSenha.Text,
                    Status = cmbStatus.SelectedItem.ToString() == "Ativo"
                };

                var addedUser = await _apiClient.AddUserAsync(user);
                MessageBox.Show($"Usuário {addedUser.Nome} adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UseWaitCursor = false;
            }
        }

        private async void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Selecione um usuário para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UseWaitCursor = true;
                var selectedUser = (Usuario)dgvUsuarios.CurrentRow.DataBoundItem;
                selectedUser.Nome = txtNome.Text.Trim();
                selectedUser.Senha = txtSenha.Text;
                selectedUser.Status = cmbStatus.SelectedItem.ToString() == "Ativo";

                await _apiClient.UpdateUserAsync(selectedUser.Id, selectedUser);
                MessageBox.Show("Usuário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UseWaitCursor = false;
            }
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Selecione um usuário para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedUser = (Usuario)dgvUsuarios.CurrentRow.DataBoundItem;
                var confirmResult = MessageBox.Show(
                    $"Tem certeza que deseja excluir o usuário {selectedUser.Nome}?",
                    "Confirmar exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    UseWaitCursor = true;
                    await _apiClient.DeleteUserAsync(selectedUser.Id);
                    MessageBox.Show("Usuário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                    LoadUsers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UseWaitCursor = false;
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                LimparCampos();
                return;
            }

            var selectedUser = (Usuario)dgvUsuarios.CurrentRow.DataBoundItem;
            txtNome.Text = selectedUser.Nome;
            txtSenha.Text = selectedUser.Senha;
            cmbStatus.SelectedItem = selectedUser.Status ? "Ativo" : "Inativo";
        }
    }
}