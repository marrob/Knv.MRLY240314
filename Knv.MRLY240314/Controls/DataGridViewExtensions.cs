namespace Knv.MRLY240314.Controls
{
    using System;
    using System.Reflection;
    using System.Windows.Forms;

    public static class DataGridViewExtensions
    {
        /// <summary>
        /// Double Buffering vezérlése.
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="setting"></param>
        public static void KnvDoubleBuffered(this DataGridView dataGridView, bool setting)
        {
            Type dgvType = dataGridView.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dataGridView, setting, null);
        }
    }
}
