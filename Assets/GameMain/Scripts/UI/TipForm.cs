using UnityEngine.UI;

namespace WowGame
{
    public class TipForm : UGuiForm
    {
        private Text m_SingleText;
        private Text m_MultiLineText;
        private Button m_OKBtn;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            //组件
            m_SingleText = transform.DeepFindChild<Text>("Text_TipSingle");
            m_MultiLineText = transform.DeepFindChild<Text>("Text_TipMultiLine");
            m_OKBtn = transform.DeepFindChild<Button>("Btn_OK");

            //注册按钮事件
            m_OKBtn.onClick.AddListener(Close);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            string tipText = userData as string;
            if (tipText.Length > 30)
            {
                m_MultiLineText.text = tipText;
                m_MultiLineText.gameObject.SetActive(true);
                m_SingleText.gameObject.SetActive(false);
            }
            else
            {
                m_SingleText.text = tipText;
                m_SingleText.gameObject.SetActive(true);
                m_MultiLineText.gameObject.SetActive(false);
            }
        }

        private void OnOKBtnClick()
        {
            Close();
        }
    }
}