using System;
using System.Windows.Forms;
using Npgsql;

namespace Teste_Cervantes
{
    public partial class FrmPrincipal : Form
    {
        private string conexao = "Host=localhost;Username=postgres;Password=1234;Database=teste";

        public FrmPrincipal()
        {
            InitializeComponent();
            this.Load += FrmPrincipal_Load;
            txtNum.KeyPress += txtNum_KeyPress;
            lastatus.ForeColor = Color.Black;
            lastatus.Text = "Testando Conex�o!";

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            TestarConexao();
        }

        private void TestarConexao()
        {
            using (var conn = new NpgsqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    
                    lastatus.ForeColor = Color.Green;
                    lastatus.Text = "Conex�o bem Sucedida!";
                }
                catch (Exception ex)
                {
                    lastatus.ForeColor=Color.Red;
                    lastatus.Text= $" Erro de Conex�o: { ex.Message}";
                }
            }
        }

        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCampo.Text) || !int.TryParse(txtNum.Text, out int num) || num <= 0)
            {
                MessageBox.Show("Todos os campos s�o obrigat�rios e o campo num�rico deve ser maior que zero.");
                return;
            }

            using (var conn = new NpgsqlConnection(conexao))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO cadastros (campotexto, camponum) VALUES (@campotexto, @camponum) RETURNING camponum", conn))
                {
                    cmd.Parameters.AddWithValue("campotexto", txtCampo.Text);
                    cmd.Parameters.AddWithValue("camponum", num);

                    try
                    {
                        int idCadastro = (int)cmd.ExecuteScalar();
                        RegistrarLog(conn, "INSERT");
                        MessageBox.Show("Registro adicionado com sucesso!");
                    }
                    catch (NpgsqlException ex) when (ex.SqlState == "23505")
                    {
                        MessageBox.Show("Erro: o n�mero j� existe. Por favor, insira um n�mero �nico.");
                    }
                    catch (NpgsqlException ex)
                    {
                        MessageBox.Show($"Erro ao adicionar registro: {ex.Message}");
                    }
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCampo.Text) || !int.TryParse(txtNum.Text, out int num) || num <= 0)
            {
                MessageBox.Show("Todos os campos s�o obrigat�rios e o campo num�rico deve ser maior que zero.");
                return;
            }

            using (var conn = new NpgsqlConnection(conexao))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("UPDATE cadastros SET campotexto = @campotexto WHERE camponum = @camponum RETURNING camponum", conn))
                {
                    cmd.Parameters.AddWithValue("campotexto", txtCampo.Text);
                    cmd.Parameters.AddWithValue("camponum", num);

                    try
                    {
                        int? idCadastro = cmd.ExecuteScalar() as int?;
                        if (idCadastro.HasValue)
                        {
                            RegistrarLog(conn, "UPDATE");
                            MessageBox.Show("Registro atualizado com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Registro n�o encontrado.");
                        }
                    }
                    catch (NpgsqlException ex)
                    {
                        MessageBox.Show($"Erro ao atualizar registro: {ex.Message}");
                    }
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNum.Text, out int num) || num <= 0)
            {
                MessageBox.Show("O campo num�rico deve ser maior que zero.");
                return;
            }

            using (var conn = new NpgsqlConnection(conexao))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        int? idCadastro = null;
                        using (var cmd = new NpgsqlCommand("SELECT camponum FROM cadastros WHERE camponum = @camponum", conn, trans))
                        {
                            cmd.Parameters.AddWithValue("camponum", num);
                            idCadastro = cmd.ExecuteScalar() as int?;
                        }

                        if (!idCadastro.HasValue)
                        {
                            MessageBox.Show("Registro n�o encontrado.");
                            trans.Rollback();
                            return;
                        }

                        
                        RegistrarLog(conn, "DELETE");


                        using (var cmd = new NpgsqlCommand("DELETE FROM cadastros WHERE camponum = @camponum", conn, trans))
                        {
                            cmd.Parameters.AddWithValue("camponum", num);
                            cmd.ExecuteNonQuery();
                        }

                        trans.Commit();

                        txtCampo.Text = "";
                        txtNum.Text = "";

                        MessageBox.Show("Registro exclu�do com sucesso!");
                    }
                    catch (NpgsqlException ex)
                    {
                        MessageBox.Show($"Erro ao excluir registro: {ex.Message}");
                        trans.Rollback();
                    }
                }
            }
        }

        private void RegistrarLog(NpgsqlConnection conn, string tipoOperacao)
        {
            using (var cmd = new NpgsqlCommand("INSERT INTO log_operacoes (tipo_operacao) VALUES (@tipoOperacao)", conn))
            {
                cmd.Parameters.AddWithValue("tipoOperacao", tipoOperacao);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show($"Erro ao registrar log: {ex.Message}");
                }
            }
        }
    }
}
