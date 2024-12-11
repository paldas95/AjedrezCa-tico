
using AjedrezCaótico;
using ProyectoAjedrez;
using System.Windows.Forms;

MenuForms menuForms = new MenuForms();

// Mostrar el formulario modal y capturar el resultado
DialogResult result = menuForms.ShowDialog();

using (var game = new DriverClass())
    game.Run();
