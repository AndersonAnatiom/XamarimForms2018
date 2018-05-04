using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppConsultaCep.Servicos.Modelo;
using AppConsultaCep.Servicos;
namespace AppConsultaCep
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            btn_ok.Clicked += buscarCep; 
		}
        private void buscarCep(object sender, EventArgs args)
        {

            //Logica
            string cep = txt_cep.Text.Trim();

            

            if (isValidCep(cep))
            {
                try
                {
                    Endereco end = viaCep.buscarEnderecoCep(cep);
                    if(end != null)
                    {
                        resultado.Text = string.Format("Endereço: Cidade {0}, Estado {1}, Rua {2}, Bairro {3}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("Erro","Endereço não foi encontrado: "+cep,"OK");
                    }
                   
                }catch(Exception e)
                {
                    DisplayAlert("Erro critico", "", "", "OK");
                    DisplayAlert("Erro critico", e.Message, "OK");
                }
                
            }
           

           
        }
        private bool isValidCep(string cep)
        {
            bool valido = true;
            if(cep.Length != 8)
            {
                DisplayAlert("Erro","Cep inválido","O cep deve conter 8 caracteres","OK");
                valido = false;
            }
            int novoCep = 0;
            if (!int.TryParse(cep,out novoCep))
            {
                DisplayAlert("Erro", "Cep inválido", "O cep não contém apenas números", "OK");
                valido = false;
            }
            return valido;
        }
	}
}
