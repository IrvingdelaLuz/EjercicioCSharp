using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class formNumero : Form
    {
        private SqlConnection db;
        class Registro
        {
            public List<int> Output { get; set; } = new List<int>();
            public List<string> OutputDB { get; set; } = new List<string>();
            public int Input { get; set; } = 0;
        }
        class Numero
        {
            public int numberValue { get; set; } = 0;
            public int ocurence { get; set; } = 0;
            public int? between { get; set; } = null;
        }
        private Registro registro = new Registro();
        //private Numero numero = new Numero();
        private List<Numero> numeros = new List<Numero>();

        //Base de datos Service_Based Database Numeros.mdf
        //CREATE TABLE[dbo].[Registro]
        //(

        //   [Id] INT NOT NULL PRIMARY KEY IDENTITY,

        //   [Output] VARCHAR(100) NOT NULL,

        //   [Input] INT NOT NULL
        //)

        public formNumero()
        {
            InitializeComponent();

            db = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Irving\source\repos\WindowsFormsApp1\Numeros.mdf;Integrated Security=True");
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(numRegister.Value > 0 && numRegister.Value < 10)
                {
                    registro.OutputDB.Add(numRegister.Value.ToString());
                    registro.Output.Add(int.Parse(numRegister.Value.ToString()));
                    numRegister.Value = 0;
                }
                else
                {
                    MessageBox.Show("Se deben ingresar numeros entre el 1 y el 9");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
            }
            
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            List<int> orden = registro.Output;
            int count = 1, max = 1; //Count es el conteo de ocurrencias de un numero en la lista, max es el mayor numero de ocurrencias que hay
            //int? minBetween = null;
            orden.Sort();
            var q = orden.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => new { value = y.Key, counter = y.Count() })
                .ToList();
            foreach (var item in q)
            {
                Numero n = new Numero();
                n.numberValue = item.value;
                n.ocurence = item.counter;
                numeros.Add(n);
            }
            foreach (Numero numero in numeros)
            {
                if (numero.ocurence > max)
                    max = numero.ocurence;
            }
            //for(int i = 0; i < orden.Count ; i++)
            //{
            //    if (orden[i] == orden[i + 1])
            //    {
            //        count++;
            //    }
            //    else
            //    {
            //        Numero numero = new Numero();
            //        numero.numberValue = orden[i];
            //        numero.ocurence = count;
            //        numeros.Add(numero);
            //        if (count > max)
            //            max = count;
            //        count = 1;
            //    }
            //    if (i == orden.Count - 1)
            //        break;
            //}
            if(max == 1)
            {
                txtResult.Text = "No se encuentran numeros repetidos";
                registro.Input = 0;
                InsertDB(registro);
                registro.OutputDB.Clear();
                registro.Output.Clear();
                registro.Input = 0;
            }else if(numeros.Where(x => x.ocurence == max).Count() == 1)
            {
                txtResult.Text = numeros.Where(o => o.ocurence == max).Select(x => x.numberValue).FirstOrDefault().ToString();
                registro.Input = numeros.Where(o => o.ocurence == max).Select(x => x.numberValue).FirstOrDefault();
                InsertDB(registro);
                registro.OutputDB.Clear();
                registro.Output.Clear();
                registro.Input = 0;
            }
            else
            {
                var arr = registro.OutputDB.ToArray();
                int? minBetween = null;
                //CONTAR ESPACIOS ENTRE REPETICIONES DE NUMEROS CON OCURRENCIA IGUAL A MAXIMA OCURRENCIA
                foreach (Numero numero in numeros.Where(x => x.ocurence == max))
                {
                    var startPos = registro.OutputDB.IndexOf(numero.numberValue.ToString());
                    int between = 0;
                    for (int i = startPos; i < arr.Length - 1; i++)
                    {
                        if(registro.OutputDB[startPos] != registro.OutputDB[i + 1])
                        {
                            between++;
                        }
                        else
                        {
                            if (minBetween == null)
                                minBetween = between;
                            if (numero.between == null)
                            {
                                numero.between = between;
                                if (between < minBetween)
                                    minBetween = between;
                                between = 0;
                            }else if(numero.between > between)
                            {
                                numero.between = between;
                                if (between < minBetween)
                                    minBetween = between;
                                between = 0;
                            }
                        }
                    }
                }
                //REVISAR CANTIDAD DE NUMEROS CON VALOR BETWEEN
                if(numeros.Where(x => x.between == minBetween).Count() == 1)
                {
                    int result = numeros.Where(x => x.between == minBetween).Select(a=>a.numberValue).FirstOrDefault();
                    txtResult.Text = result.ToString();
                    registro.Input = result;
                    InsertDB(registro);
                    registro.OutputDB.Clear();
                    registro.Output.Clear();
                    registro.Input = 0;
                }
                else
                {
                    int? index = null;
                    int resultIndex = 0;
                    foreach (Numero numero in numeros.Where(x => x.between != null))
                    {
                        if(index == null)
                        {
                            index = registro.OutputDB.IndexOf(numero.numberValue.ToString());
                            resultIndex = numero.numberValue;
                        }else if(index > registro.OutputDB.IndexOf(numero.numberValue.ToString()))
                        {
                            index = registro.OutputDB.IndexOf(numero.numberValue.ToString());
                            resultIndex = numero.numberValue;
                        }
                    }
                    txtResult.Text = resultIndex.ToString();
                    registro.Input = resultIndex;
                    InsertDB(registro);
                    registro.OutputDB.Clear();
                    registro.Output.Clear();
                    registro.Input = 0;
                }
                
            }
            
        }

        private void InsertDB(Registro r)
        {
            string arr = string.Join(",", r.OutputDB);
            int added = 0;
            arr.Replace("\"", "'");

            try
            {
                if (db.State != ConnectionState.Open)
                    db.Open();

                string addQuery = "INSERT INTO dbo.Registro (Output, Input)" +
                                "VALUES ('" + arr +
                                "', " + r.Input + ")";

                SqlCommand command = new SqlCommand(addQuery, db);
                added = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
        }
    }
}
