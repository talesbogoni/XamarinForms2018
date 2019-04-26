using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Botao_Clicked(object sender, EventArgs e)
        {
            string cep = CEP.Text.Trim();
            Endereco end = ViaVepServico.BuscarEnderecoViaCep(cep);
            RESULTADO.Text = string.Format("Endereço: {0}-{1}\n{2}\n{3}",
                end.localidade, end.unidade, end.bairro, end.logradouro);
        }
    }
}
