using LibroClubWeb.LibroClubWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibroClubWeb.Views
{
	public class PersonalSales
	{
		public string Name { get; set; }
		public int Sales { get; set; }
	}
	public partial class Chart : System.Web.UI.Page
	{
		public static LibroClubWS.ServicioWSClient daoPersonal;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["Gerente"] != null)
			{
				if (!IsPostBack)
				{
					// Si es la primera carga de la página, cargar el gráfico con las ventas por defecto.
					CargarGrafico("Ventas");
				}
			}
			else
			{
				Response.Redirect("/Login.aspx");
			}
		}

		protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Obtener el valor seleccionado del DropDownList
			string seleccion = ddlChart.SelectedValue;

			// Cargar el gráfico con el tipo de datos correspondiente.
			CargarGrafico(seleccion);
		}
		private void CargarGrafico(string tipo)
		{
			daoPersonal = new LibroClubWS.ServicioWSClient();
			var data = ListarPersonal(tipo);
			var script = GenerateChartScript(data);
			ClientScript.RegisterStartupScript(this.GetType(), "LoadChart", script, true);
		}

		private string GenerateChartScript(List<PersonalSales> data)
		{
			var categories = string.Join(",", data.Select(d => $"'{d.Name}'"));
			var salesData = string.Join(",", data.Select(d => d.Sales.ToString()));

			return $@"
        document.addEventListener('DOMContentLoaded', function () {{
            var options = {{
                chart: {{
                    type: 'line',
                    height: 400,
                    background: '#ffffff', // Fondo blanco para un look limpio
                    dropShadow: {{
                        enabled: true,
                        color: '#000',
                        top: 18,
                        left: 7,
                        blur: 10,
                        opacity: 0.2
                    }},
                    toolbar: {{
                        show: false // Esconde la barra de herramientas para un look más limpio
                    }}
                }},
                colors: ['#732988'], // Color de la línea
                dataLabels: {{
                    enabled: false, // Muestra las etiquetas de los datos
                    style: {{
                        colors: ['#732988'] // Color de las etiquetas de los datos
                    }}
                }},
                stroke: {{
                    curve: 'smooth',
                    width: 2
                }},
                grid: {{
                    borderColor: '#e7e7e7',
                    row: {{
                        colors: ['#f3f3f3', 'transparent'], // Alterna colores de las filas
                        opacity: 0.5
                    }},
                }},
                markers: {{
                    size: 5,
                    colors: ['#732988'],
                    strokeColors: '#fff',
                    strokeWidth: 2,
                    hover: {{
                        size: 7,
                    }}
                }},
                series: [{{
                    name: 'Sales',
                    data: [{salesData}]
                }}],
                xaxis: {{
                    categories: [{categories}],
                    title: {{
                        text: 'Personal',
                        style: {{
                            color: '#333',
                            fontSize: '12px',
                            fontWeight: 'bold',
                            fontFamily: 'Arial, sans-serif'
                        }}
                    }}
                }},
                yaxis: {{
                    title: {{
                        text: 'Sales',
                        style: {{
                            color: '#333',
                            fontSize: '12px',
                            fontWeight: 'bold',
                            fontFamily: 'Arial, sans-serif'
                        }}
                    }},
                    min: 0
                }},
                title: {{
                    text: 'Sales Overview',
                    align: 'left',
                    margin: 20,
                    offsetX: 0,
                    offsetY: 0,
                    floating: false,
                    style: {{
                        fontSize: '18px',
                        fontWeight: 'bold',
                        fontFamily: 'Arial, sans-serif',
                        color: '#263238'
                    }}
                }},
                tooltip: {{
                    enabled: true,
                    theme: 'light'
                }},
                legend: {{
                    show: true,
                    position: 'top',
                    horizontalAlign: 'right',
                    floating: true,
                    offsetY: -25,
                    offsetX: -5
                }}
            }};

            var chart = new ApexCharts(document.querySelector('#chart'), options);
            chart.render();
        }});
    ";
		}


		private List<PersonalSales> ListarPersonal(string tipo)
		{
			daoPersonal = new ServicioWSClient();
			object[] usuariosArray;
			usuariosArray = daoPersonal.listarPersonalSede((int)Session["GerenteIdSede"]);

			var personales = new BindingList<personal>(
				usuariosArray.Cast<personal>().ToList()
			);
			var sortedPersonales = personales.OrderBy(p => p.cant_ejemplares_vendidos).ToList();

			return sortedPersonales.Select(p => new PersonalSales
			{
				Name = p.nombre,
				Sales = tipo == "Prestamos" ? p.cant_ejemplares_prestados : p.cant_ejemplares_vendidos
			}).ToList();
		}
	}
}