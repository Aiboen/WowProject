using UnityEngine.UI;

namespace WowGame
{
    public class LoginForm : UGuiForm
    {
        private InputField m_IdInput;
        private InputField m_PwInput;
        private Button m_LoginBtn;
        private Button m_RegBtn;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            //寻找组件
            m_IdInput = transform.DeepFindChild<InputField>("IF_UserID");
            m_PwInput = transform.DeepFindChild<InputField>("IF_PassWord");
            m_LoginBtn = transform.DeepFindChild<Button>("Btn_Login");
            m_RegBtn = transform.DeepFindChild<Button>("Btn_Regist");

            //注册按钮事件
            m_LoginBtn.onClick.AddListener(OnLoginBtnClick);
            m_RegBtn.onClick.AddListener(OnRegBtnClick);
        }

        private void OnLoginBtnClick()
        {
            var pwIsTrue = CheckedPw();
            if (pwIsTrue)
            {
                GameEntry.UI.OpenUIForm(UIFormId.ChoiceForm);
            }
            else
            {
                string tipContent = "账号或者密码不正确";
                GameEntry.UI.OpenUIForm(UIFormId.TipForm, tipContent);
            }
        }

        private void OnRegBtnClick()
        {
            GameEntry.UI.OpenUIForm(UIFormId.RegisterForm, m_IdInput.text);
        }

        private bool CheckedPw()
        {
            //链接服务器检查密码账户
            //相同返回true
            return true;
            //不相同返回false
        }
    }
}