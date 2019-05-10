using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.WindowsAPI;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.Finders;
using System.Windows.Automation;



namespace Addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DLTWINTITLE = "Delete group";

        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void Remove(int v)
        {
            Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            root.Nodes[v].Select();

            Window dlt = ConfirmDelete(dialogue);
            dlt.Get<Button>("uxOKAddressButton").Click();
            CloseGroupsDialogue(dialogue);
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });

            }
 
            CloseGroupsDialogue(dialogue);
            return list;
        }

        public void Add(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialogue();
            manager.MainWindow.Get<Button>("uxNewAddressButton").Click();
            TextBox textbox = (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textbox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialogue(dialogue);
        }

        private void CloseGroupsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }

        private Window OpenGroupsDialogue()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();

            return manager.MainWindow.ModalWindow(GROUPWINTITLE);

        }

        private Window ConfirmDelete(Window dialogue)
        {
 
            dialogue.Get<Button>("uxDeleteAddressButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE).ModalWindow(DLTWINTITLE);
        }
    }


}