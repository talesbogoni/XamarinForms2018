using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ConsultarCEP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaLivro : ContentPage
    {
        public ConsultaLivro()
        {
            InitializeComponent();
        }

        private void Botao_Clicked(object sender, EventArgs e)
        {
            string id = LIVRO.Text.Trim();
            Livro livro = ConsultaLivros.BuscarLivros(id);
            if (livro != null)
                RESULTADO.Text = string.Format("Livro: {0} - {1}\n{2} - {3}\n",
                    livro.id, livro.titulo, livro.autor, livro.ano);
            else
                RESULTADO.Text = "Livro não cadastrado";
        }

        private void Botao_Tudo_Clicked(object sender, EventArgs e)
        {
            List <Livro> livros = ConsultaLivros.BuscarLivros();
            RESULTADO.Text = "";
            if(livros!=null)
                for (int i=0; i<livros.Count(); i++)
                    RESULTADO.Text+= string.Format("Livro: {0} - {1}\n{2} - {3}\n",
                        livros.ElementAt(i).id, 
                        livros.ElementAt(i).titulo, 
                        livros.ElementAt(i).autor, 
                        livros.ElementAt(i).ano
                        );
            else
                RESULTADO.Text = "Cadastro Vazio";
        }

        private void Botao_Inserir_Clicked(object sender, EventArgs e)
        {
            Livro livro = new Livro();
            livro.titulo = TITULO.Text;
            livro.autor = AUTOR.Text;
            livro.ano = Convert.ToInt32(ANO.Text);
            ConsultaLivros.InserirLivroAsync(livro);
        }
    }
}