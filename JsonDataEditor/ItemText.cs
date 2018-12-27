
using System.Windows.Forms;

namespace JsonDataEditor {


    // Declare the metric units interface:


    public class ItemTextBox : TextBox {
        public int index;
        private TextBox textBox;
        private ComboBox comboBox;
        
        public ItemTextBox() {

        }

        public ItemTextBox(int i) {
            this.index = i;
            //this.textBox = new TextBox();
            //this.comboBox = new ComboBox();
        }
        
      
    


    }

}
