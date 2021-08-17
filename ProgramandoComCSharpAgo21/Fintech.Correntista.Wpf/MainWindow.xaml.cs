using FinTech.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fintech.Correntista.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window // herança
    {

        public List<Cliente> Clientes = new List<Cliente>();
        public Cliente ClienteSelecionado { get; set; }

        public MainWindow() // construtor
        {
            InitializeComponent();
            PopularControles();
        }

        private void PopularControles()
        {
            sexoComboBox.Items.Add(Sexo.Feminino); // Acesso com referencia do Enum de outro projeto 
            sexoComboBox.Items.Add(Sexo.Masculino);
            sexoComboBox.Items.Add(Sexo.Outro);
            clienteDataGrid.ItemsSource = Clientes;

            tipoContaComboBox.Items.Add(TipoConta.ContaCorrente);
            tipoContaComboBox.Items.Add(TipoConta.ContaEspecial);
            tipoContaComboBox.Items.Add(TipoConta.Poupanca);
            Banco bancos = new Banco();
            bancos.Nome = "Banco 1";
            bancos.Numero = 901;

            bancoComboBox.Items.Add(bancos);
            bancoComboBox.Items.Add(new Banco() { Nome = "Banco 2", Numero = 923 });

            operacaoComboBox.Items.Add(Operacao.Deposito);
            operacaoComboBox.Items.Add(Operacao.Saque);
        }

        private void incluirClienteButton_Click(object sender, RoutedEventArgs e)
        {

            string logradouroCliente = logradouroTextBox.Text;
            string cidadeCliente = cidadeTextBox.Text;
            string cepCliente = cepTextBox.Text;
            string numeroCliente = numeroTextBox.Text;

            //Instanciar Classes
            Endereco endereco = new Endereco(logradouroCliente, cepCliente, cidadeCliente, numeroCliente)
            {
                CEP = cepCliente,
                Cidade = cidadeCliente,
                Logradouro = logradouroCliente,
                Numero = numeroCliente
            };
            Cliente newClient = new Cliente()
            {
                CPF = cpfTextBox.Text,
                Nome = nomeTextBox.Text,
                DataNascimento = Convert.ToDateTime(dataNascimentoTextBox.Text),
                Sexo = (Sexo)sexoComboBox.SelectedItem,
                EnderecoResidencial = endereco.Logradouro + ", " + endereco.Numero + " " + endereco.Cidade + " - " + endereco.CEP
            };

            Clientes.Add(newClient);

            MessageBox.Show("Cliente cadastrado com sucesso!");
            LimparTextBoxesCliente();
            clienteDataGrid.Items.Refresh();
            pesquisaTab.Focus();
        }

        private void LimparTextBoxesCliente()
        {
            cpfTextBox.Clear();
            dataNascimentoTextBox.Clear();
            logradouroTextBox.Clear();
            nomeTextBox.Clear();
            numeroTextBox.Clear();
            cidadeTextBox.Clear();
            cepTextBox.Clear();
            sexoComboBox.SelectedIndex = -1;
        }

        private void SelecionarClienteButtonClick(object sender, RoutedEventArgs e) // usamos o sender para pegar as informações do botão que foi usaod no Click
        {
            SelecionaCliente(sender);

            clienteTextBox.Text = $"{ ClienteSelecionado.Nome} - {ClienteSelecionado.CPF}";

            contasTabItem.Focus();
        }

        private void SelecionaCliente(object sender)
        {
            var botaoClicado = (Button)sender; // Button, var 
            var clienteSelecionado = botaoClicado.DataContext;
            ClienteSelecionado = (Cliente)clienteSelecionado;
        }

        private void IncluirContaButton_Click(object sender, RoutedEventArgs e)
        {
            Conta conta = null;

            var agencia = new Agencia();
            agencia.Banco = (Banco)bancoComboBox.SelectedItem;
            agencia.Numero = Convert.ToInt32(numeroAgenciaTextBox.Text);
            agencia.DigitoVerificador = dvAgenciaTextBox.Text;

            var numero = Convert.ToInt32(numeroContaTextBox.Text);
            var digitoVerificador = dvContaTextBox.Text;

            switch ((TipoConta)tipoContaComboBox.SelectedItem)
            {
                case TipoConta.ContaCorrente:
                    conta = new ContaCorrente(agencia, numero, digitoVerificador);

                    break;
                case TipoConta.ContaEspecial:
                    var limite = Convert.ToDecimal(limiteTextBox.Text);
                    conta = new ContaEspecial(agencia, numero, digitoVerificador,limite);
                    break;
                case TipoConta.Poupanca:
                    conta = new Poupanca(agencia, numero, digitoVerificador);
                    break;
            }
            ClienteSelecionado.Contas.Add(conta);

            MessageBox.Show("Conta adicionada com sucesso!");
            LimparControlesConta();
            clienteDataGrid.Items.Refresh();
            clienteTabItem.Focus();
            //pesquisaTab.Focus();
        }

        private void LimparControlesConta()
        {
            clienteTextBox.Clear();
            bancoComboBox.SelectedIndex = -1;
            numeroAgenciaTextBox.Clear();
            numeroContaTextBox.Clear();
            dvAgenciaTextBox.Clear();
            dvContaTextBox.Clear();
            tipoContaComboBox.SelectedIndex = -1;
            limiteTextBox.Clear();
        }

        private void TipoContaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tipoContaComboBox.SelectedIndex == -1) return;
            
                var tipoConta = (TipoConta)tipoContaComboBox.SelectedItem;

                if (tipoConta == TipoConta.ContaEspecial)
                {
                    limiteDockPanel.Visibility = Visibility.Visible;
                    limiteTextBox.Focus();
                }
                else
                {
                    limiteDockPanel.Visibility = Visibility.Collapsed;
                }
            
        }

        private void SelecionarContaButtonClick(object sender, RoutedEventArgs e)
        {
            SelecionaCliente(sender);

            contaTextBox.Text = $"{ ClienteSelecionado.Nome} - {ClienteSelecionado.CPF}";
            contaComboBox.ItemsSource = ClienteSelecionado.Contas;
            contaComboBox.Items.Refresh();

            operacoesTabItem.Focus();
        }

        /// <summary>
        /// um dos metodos mais importantes, conceito de OO
        /// </summary>
        private void incluirOperacaoButtonClick(object sender, RoutedEventArgs e)
        {
            //Ja utiliza todos dados do form que sai do cliente selecionado
            Conta account = (Conta)contaComboBox.SelectedItem;
            Operacao operacao = (Operacao)operacaoComboBox.SelectedItem;
            decimal valor = Convert.ToDecimal(valorTextBox.Text);

            account.EfetuarOperação(valor, operacao);
            AtualizaGridMoviemtnac(account);

        }

        private void AtualizaGridMoviemtnac(Conta account)
        {
            movimentacaoDataGrid.ItemsSource = account.Movimentos;
            movimentacaoDataGrid.Items.Refresh();

            saldoTextBox.Text = account.Saldo.ToString("c");
        }

        private void contaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (contaComboBox.SelectedIndex == -1) return;

            Conta account = (Conta)contaComboBox.SelectedItem;
            AtualizaGridMoviemtnac(account);

        }
    }
}
