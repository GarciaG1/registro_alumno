using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//Desarrollo de Aplicaciones Moviles
//19210493
//Gabriel Garcia Perez

namespace registro_alumno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
        }

        private async void btningresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                //cadena de conexion
                string conexion = "Server = 172.31.181.75,1433; Database=Colegio;User Id=GGP; Password=asdfg";

                //Creamos la conexion a la bd
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    await con.OpenAsync();
                    await DisplayAlert("Conexion a BD", "Conexion a la BD Establecida", "ok");

                    //Consulta SQL para insertar Datos
                    string sentencia = "INSERT INTO Alumno (ncontrol,nombre,apellidos,telefono,direccion,curp,nss)" +
                        "values (@Ncontrol,@Nombre,@Apellidos, @Telefono, @Direccion,@CURP,@NSS";
                    //Mandamos los datos de la Forma hacia la BD
                    using (SqlCommand command = new SqlCommand(sentencia, con))
                    {
                        command.Parameters.AddWithValue("@Ncontrol", ncontrol.Text);
                        command.Parameters.AddWithValue("@Nombre", name.Text);
                        command.Parameters.AddWithValue("@Apellidos", apellidos.Text);
                        command.Parameters.AddWithValue("@Telefono", tel.Text);
                        command.Parameters.AddWithValue("@Direccion", direccion.Text);
                        command.Parameters.AddWithValue("@CURP", curp.Text);
                        command.Parameters.AddWithValue("@NSS", nss.Text);

                        //Ejecutaos la consulta de Insercion
                        int rowsAffected = await command.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            await DisplayAlert("Conexion a BD", "Datos Insertados con Exito", "OK");

                        }
                        else
                        {
                            await DisplayAlert("Conexion a BD", "Datos No Insertados", "OK");
                        }
                    }


                }
            }
            catch (Exception ) {
                await DisplayAlert("Conexion a BD", "Conexion a la BD No Establecida", "OK");
                    }


        }

        private void btnnuevo_Clicked(object sender, EventArgs e)
        {

        }
    }
}