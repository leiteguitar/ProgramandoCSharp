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

        public MainWindow() // construtor
        {
            InitializeComponent();
            PopularControles();
        }

        private void PopularControles()
        {
            sexoComboBox.Items.Add(Sexo.Feminino); // Aceso com referencia do Enum de outro projeto 
            sexoComboBox.Items.Add(Sexo.Masculino);
            sexoComboBox.Items.Add(Sexo.Outro);
            clienteDataGrid.ItemsSource = Clientes;

        }

        private void incluirClienteButton_Click(object sender, RoutedEventArgs e)
        {
            //Instanciar Classe
            Endereco endereco = new Endereco()
            {
                CEP = cepTextBox.Text,
                Cidade = cidadeTextBox.Text,
                Logradouro = logradouroTextBox.Text,
                Numero = numeroTextBox.Text
            };
            Cliente newClient = new Cliente()
            {
                CPF = cpfTextBox.Text,
                Nome = nomeTextBox.Text,
                DataNascimento = Convert.ToDateTime(dataNascimentoTextBox.Text),
                Sexo = (Sexo)sexoComboBox.SelectedItem,
                EnderecoResidencial = endereco
            };
             
            Clientes.Add(newClient);

            MessageBox.Show("Cliente cadastrado com sucesso!");
            LimparTextBoxesCliente();
            clienteDataGrid.Items.Refresh();
            pesquisaTab.Focus();
        }
        /// <summary>
        /// Limpa os TextBoxes do form de Cliente
        /// </summary>
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
    }
}
