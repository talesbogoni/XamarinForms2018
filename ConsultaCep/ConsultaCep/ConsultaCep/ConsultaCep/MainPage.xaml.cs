using ConsultaCep.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConsultaCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BOTAO_Clicked(object sender, EventArgs e)
        {
            string cep = CEP.Text.Trim();
            if (ValidaCep(cep))
            {
                Endereco end = ViaCep.BuscarEnderecoViaCep(cep);
                if (end != null)
                {
                    RESULTADO.Text = string.Format("Cidade: {0}/{1}\n" +
                        "Bairro: {2}\n" +
                        "Endereço: {3}\n" +
                        "Complemento: {4}", end.localidade, end.uf,
                        end.bairro, end.logradouro, end.complemento);
                } else
                {
                    RESULTADO.Text = "Este CEP não existe";
                }
            }
            else
                RESULTADO.Text = "Formato do CEP inválido\nUtilize apenas números com 8 posições";

        }

        private bool ValidaCep(string cep)
        {
            if (cep.Length != 8)
                return false;
            try
            {
                long aux = Convert.ToInt64(cep);
                return true;
            } catch (Exception e)
            {
                return false;
            }
        }
    }
}
