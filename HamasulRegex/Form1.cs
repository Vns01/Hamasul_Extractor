using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HamasulRegex
{
    public partial class Form1 : Form
    {
        #region variáveis globais
        //Classe que conterá o arquivo final
        private StringBuilder st;

        //Regex para os matches no arquivo
        private string pattern_QuebraArquivos = @"(^10;.*\n){1}((?:^0[1234].*\n(?:\s*|\n*)*)*)((?:^05;.*\n)*)";
        private string pattern_QuebraLinhas = @"\n";
        private string pattern_Protocolo = @"((^00;.*\n)+)(^00T.*\n){1}";

        //Nome de arquivo tratado
        private string FileName = "Hamasul_Modelo.txt";
        #endregion

        #region Construtor
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Start
        private void button1_Click(object sender, EventArgs e)
        {
        
            if(opfDialog.ShowDialog() == DialogResult.OK && opfDialog.FileName.Length > 0)
            {
                if (MessageBox.Show($"O modelo será gerado com base no arquivo {opfDialog.FileName}", "Clique SIM para continuar e Não para sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    st = new StringBuilder();
                    Regex regex_QuebraLinhas = new Regex(pattern_QuebraLinhas, RegexOptions.Multiline);

                    txtPath.Text += opfDialog.FileName;

                    //Lê o arquivo
                    string texto = File.ReadAllText(opfDialog.FileName, Encoding.GetEncoding(CultureInfo.GetCultureInfo("pt-BR").TextInfo.ANSICodePage));

                    //Match para buscar as linhas de protocolo
                    MatchCollection match1 = matchExecute(texto, pattern_Protocolo);

                    //Adiciona as linhas de protocolo na string mutável que conterá o arquivo tratado
                    st.Append(match1[0].Groups[0].ToString());

                    //Match para buscar todos os Prédios no arquivo inteiro
                    MatchCollection match2 = matchExecute(texto, pattern_QuebraArquivos);
                    
                    //Variáveis auxiliares
                    string[] array;
                    string aux = "";


                    //Adiciona as linhas 10,01,02,03,04 e 05 (apenas a quantidade que o usuário definir) na string mutável
                    for (int i = 0; i < match2.Count; i++)
                        for (int j = 1; j < match2[i].Groups.Count; j++)
                        {
                            if (j == match2[i].Groups.Count - 1)
                            {
                                array = regex_QuebraLinhas.Split(match2[i].Groups[j].ToString(), (int)numRegistros.Value + 1);
                                aux = addString(array);
                                st.AppendLine(aux);
                            }
                            else
                                st.Append(match2[i].Groups[j]);
                        }
                    
                    //Cria arquivo com base na string mutável st
                    criarArquivo(st.ToString(), $"{retornaNomeDiretorioAtual(opfDialog.FileName)}\\{FileName}");

                    //Messagem de Conclusão
                    MessageBox.Show($"O arquivo {FileName} foi gerado com sucesso.", "Concluído!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Default
                    clear();
                }
            }
        }

        #endregion

        #region Métodos Auxiliares
        /// <summary>
        /// Executa um match em um arquivo texto
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private MatchCollection matchExecute(string texto,  string pattern)
        {
            Regex regex = new Regex(pattern, RegexOptions.Multiline);
            MatchCollection match = regex.Matches(texto);

            return match;
        }

        /// <summary>
        /// Retorna os componentes para seus valores default
        /// </summary>
        private void clear()
        {
            txtPath.Text = "";
            numRegistros.Value = 5;
        }

        /// <summary>
        /// Cria arquivo tratado
        /// </summary>
        /// <param name="text"></param>
        /// <param name="path"></param>
        private void criarArquivo(string text, string path)
        {
            if (File.Exists(path))
                File.Delete(path);

            File.WriteAllText(path, text, Encoding.GetEncoding(CultureInfo.GetCultureInfo("pt-BR").TextInfo.ANSICodePage));

        }

        /// <summary>
        /// Retorna o nome do diretório com base no path recebido
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string retornaNomeDiretorioAtual(string fileName)
        { 
            FileInfo fileInfo = new FileInfo(fileName);
            return fileInfo.DirectoryName;
        }

        /// <summary>
        /// Adiciona os valores  da linha  5 com base na quantidade especificada pelo usuario
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
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
    #endregion
}