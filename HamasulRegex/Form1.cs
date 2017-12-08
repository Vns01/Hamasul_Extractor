using System;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace HamasulRegex
{
    public partial class Form1 : Form
    {
        //Classe que conterá o arquivo final
        StringBuilder st;

        //Regex para os matches no arquivo
        string pattern_QuebraArquivos = @"(^10;.*\n){1}((?:^01;.*\n)*)^(\n|\s)*((?:^02;.*\n)*)^(\n|\s)*((?:^03;.*\n)*)^(\n|\s)*((?:^04;.*\n)*)^(\n|\s)*((?:^05;.*\n)+)";
        string pattern_LinhasDestinatario = @"((^05;.*\n)+)";
        string pattern_QuebraLinhas = @"\n";
        string pattern_Protocolo = @"((^00;.*\n)+)(^00T.*\n){1}";
        string FileName = "Hamasul_Modelo.txt";
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(opfDialog.ShowDialog() == DialogResult.OK && opfDialog.FileName.Length > 0)
            {
                
                st = new StringBuilder();
                Regex regex_QuebraArquivos = new Regex(pattern_QuebraArquivos, RegexOptions.Multiline);
                Regex regex_LinhasDestinatario = new Regex(pattern_LinhasDestinatario, RegexOptions.Multiline);
                Regex regex_QuebraLinhas = new Regex(pattern_QuebraLinhas, RegexOptions.Multiline);
                Regex regex_Protocolo = new Regex(pattern_Protocolo, RegexOptions.Multiline);
                if (MessageBox.Show($"O modelo será gerado com base no arquivo {opfDialog.FileName}", "Clique SIM para continuar e Não para sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtPath.Text += opfDialog.FileName;
                    st = new StringBuilder();
                    Regex regex_QuebraArquivos = new Regex(pattern_QuebraArquivos, RegexOptions.Multiline);
                    Regex regex_LinhasDestinatario = new Regex(pattern_LinhasDestinatario, RegexOptions.Multiline);
                    Regex regex_QuebraLinhas = new Regex(pattern_QuebraLinhas, RegexOptions.Multiline);
                    Regex regex_Protocolo = new Regex(pattern_Protocolo, RegexOptions.Multiline);

                    //Lê o arquivo
                    string texto = File.ReadAllText(opfDialog.FileName, Encoding.GetEncoding(CultureInfo.GetCultureInfo("pt-BR").TextInfo.ANSICodePage));

                    MatchCollection match2 = regex_Protocolo.Matches(texto);
                    st.Append(match2[0].Groups[0].ToString());

                    //Efetua primeiro match
                    MatchCollection match = regex_QuebraArquivos.Matches(texto);

                    string[] array;
                    string aux = "";

                    for (int i = 0; i < match.Count; i++)
                        for (int j = 1; j < match[i].Groups.Count; j++)
                        {
                            if (regex_LinhasDestinatario.IsMatch(match[i].Groups[j].ToString()))
                            {
                                array = regex_QuebraLinhas.Split(match[i].Groups[j].ToString(), (int)numRegistros.Value + 1);

                                aux = addString(array);

                                st.AppendLine(aux);

                            }
                            else
                                st.Append(match[i].Groups[j]);
                        }

                    criarArquivo(st.ToString(), $"{retornaNomeDiretorioAtual(opfDialog.FileName)}\\{FileName}");
                    MessageBox.Show($"O arquivo {FileName} foi gerado com sucesso.", "Concluído!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }
            }
        }

        private void clear()
        {
            txtPath.Text = "";
        }

        private void criarArquivo(string text, string path)
        {
            if (File.Exists(path))
                File.Delete(path);

            File.WriteAllText(path, text, Encoding.GetEncoding(CultureInfo.GetCultureInfo("pt-BR").TextInfo.ANSICodePage));

        }

        private string retornaNomeDiretorioAtual(string fileName)
        { 
            FileInfo fileInfo = new FileInfo(fileName);
            return fileInfo.DirectoryName;
        }

        private string addString(string[] array)
        {
            string aux = "";

            if (array.Length <= numRegistros.Value)
            {
                for (int i = 0; i < array.Length-1; i++)
                {
                    aux += $"{array[i]}\n";
                }
            }
            else
                for (int i= 0; i < numRegistros.Value; i++)
                    aux += $"{array[i]}\n";

            return aux;
        }
    }
}
