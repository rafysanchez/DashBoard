namespace ScheduleService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.RpaAgendamento = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            // 
            // RpaAgendamento
            // 
            this.RpaAgendamento.Account = System.ServiceProcess.ServiceAccount.LocalService;
            //this.RpaAgendamento.Password = null;
            //this.RpaAgendamento.Username = null;
            // 
            // serviceInstaller1
            // 
            this.serviceInstaller1.ServiceName = "RPAScheduleService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.RpaAgendamento,
            this.serviceInstaller1});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller RpaAgendamento;
        private System.ServiceProcess.ServiceInstaller serviceInstaller1;
    }
}