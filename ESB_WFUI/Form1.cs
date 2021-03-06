﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESB_WFUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LimparCampos()

        {

            idTexto.Text = "";
            nomeTexto.Text = "";
            nascimentoTexto.Text = "";
            enderecoTexto.Text = "";
            numEndTexto.Text = "";
            endCompTexto.Text = "";
            cepTexto.Text = "";
            cidadeTexto.Text = "";
            estadoTexto.Text = "";
            foneTexto.Text = "";
            celularTexto.Text = "";
            
        }

        //Botao Consulta
        private void button1_Click(object sender, EventArgs e)
        {
            using (WebClient webClient = new System.Net.WebClient())
            {
                //criando conexão
                WebClient n = new WebClient();
                //URL do mule local
                var json = n.DownloadString("http://localhost:8081/?comandosql=consultar&usuarioID=" + idTexto.Text);
                //convertendo pra string just in case
                string valorOriginal = Convert.ToString(json);
                //debug
                Console.WriteLine(json);
                //Fazendo o parse com o Json.Net usando array
                usuarioSOA[] usuario_raw = JsonConvert.DeserializeObject<usuarioSOA[]>(json);
                usuarioSOA usuario = usuario_raw[0];
                //Esse metodo funcionaria se o MULE passasse um json apenas e não um array de objetos :/
                //usuarioSOA usuario = JsonConvert.DeserializeObject<usuarioSOA>(json);
                //Setando os campos da interface com os valores do Json
                nomeTexto.Text = usuario.nome;
                nascimentoTexto.Text = usuario.data_nasc;
                enderecoTexto.Text = usuario.endereco;
                numEndTexto.Text = usuario.numero_end;
                endCompTexto.Text = usuario.end_complemento;
                cepTexto.Text = usuario.cep;
                cidadeTexto.Text = usuario.cidade;
                estadoTexto.Text = usuario.UF;
                foneTexto.Text = usuario.telefone;
                celularTexto.Text = usuario.celular;
                debugBox.Text = valorOriginal;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void inserirBotao_Click(object sender, EventArgs e)
        {

        }

        //Botao Apagar
        private void apagaBotao_Click_1(object sender, EventArgs e)
        {
            using (WebClient webClient = new System.Net.WebClient())
            {
                //criando conexão
                WebClient n = new WebClient();
                //URL do mule local
                var text = n.DownloadString("http://localhost:8081/?comandosql=apagar&usuarioID=" + idTexto.Text);
                //convertendo pra string just in case
                string valorOriginal = Convert.ToString(text);
                //debug
                Console.WriteLine(valorOriginal);
                debugBox.Text = valorOriginal;
                //Fazendo o parse com o Json.Net usando array
                //usuarioSOA[] usuario_raw = JsonConvert.DeserializeObject<usuarioSOA[]>(json);
                //usuarioSOA usuario = usuario_raw[0];
                //Esse metodo funcionaria se o MULE passasse um json apenas e não um array de objetos :/
                //usuarioSOA usuario = JsonConvert.DeserializeObject<usuarioSOA>(json);
                //Mule sempre voltar quantas linhas foram apagadas no metodo Delete, como estamos procurando apenas UMA coluna
                //se ele achar a mesma o retorno no html será UM, se não 0.
                if (valorOriginal == "1")
                {
                    MessageBox.Show("Usuario Apagado");
                    LimparCampos();
                } else {
                    MessageBox.Show("Erro");
                }
            }
        }
        
        //Botao Alterar
        private void alteraBotao_Click_1(object sender, EventArgs e)
        {
            using (WebClient webClient = new System.Net.WebClient())
            {
                //criando conexão
                WebClient n = new WebClient();
                //URL do mule local
                var text = n.DownloadString("http://localhost:8081/?comandosql=alterar&idusuario_soa=" + idTexto.Text + "&nome=" + nomeTexto.Text + "&data_nasc="+ nascimentoTexto.Text +"&endereco=" + enderecoTexto.Text + "&numero_end=" + numEndTexto.Text + "&end_complemento=" + endCompTexto.Text + "&cep="+ cepTexto.Text +"&cidade=" + cidadeTexto.Text + "&UF= " + estadoTexto.Text + "&telefone=" + foneTexto.Text + "&celular=" + celularTexto.Text);
                //convertendo pra string just in case
                string valorOriginal = Convert.ToString(text);
                //debug
                Console.WriteLine(valorOriginal);
                debugBox.Text = valorOriginal;
            }
        }

        private void inserirBotao_Click_1(object sender, EventArgs e)
        {
            using (WebClient webClient = new System.Net.WebClient())
            {
                //criando conexão
                WebClient n = new WebClient();
                //URL do mule local
                var text = n.DownloadString("http://localhost:8081/?comandosql=&idusuario_soa=" + idTexto.Text + "&nome=" + nomeTexto.Text + "&data_nasc=" + nascimentoTexto.Text + "&endereco=" + enderecoTexto.Text + "&numero_end=" + numEndTexto.Text + "&end_complemento=" + endCompTexto.Text + "&cep=" + cepTexto.Text + "&cidade=" + cidadeTexto.Text + "&UF= " + estadoTexto.Text + "&telefone=" + foneTexto.Text + "&celular=" + celularTexto.Text);
                //convertendo pra string just in case
                string valorOriginal = Convert.ToString(text);
                //debug
                Console.WriteLine(valorOriginal);
                debugBox.Text = valorOriginal;
                //Se retornar 1 - Message Box Dizendo que inseriu com sucesso e Limpa Campos
                if (valorOriginal == "1")
                {
                    MessageBox.Show("Usuario Inserido");
                    LimparCampos();
                }
                else {
                    MessageBox.Show("Erro");
                }
            }
        }

        private void limpaBotao_Click_1(object sender, EventArgs e)
        {
            LimparCampos();
            debugBox.Text = "";
        }
    }
}
