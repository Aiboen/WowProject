//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

namespace WowGame
{
    /// <summary>
    /// 界面编号。
    /// </summary>
    public enum UIFormId : byte
    {
        Undefined = 0,

        /// <summary>
        /// 弹出框。
        /// </summary>
        TipForm = 1,

        /// <summary>
        /// 登录
        /// </summary>
        LoginForm = 100,

        /// <summary>
        /// 注册
        /// </summary>
        RegisterForm = 101,

        /// <summary>
        /// 选择英雄
        /// </summary>
        ChoiceForm = 102,

        /// <summary>
        /// 创建角色
        /// </summary>
        CharacterCreateForm = 103,

        /// <summary>
        /// 加载
        /// </summary>
        LoadForm = 104,

        /// <summary>
        /// 游戏界面
        /// </summary>
        GameForm = 105,

        /// <summary>
        /// 遮罩
        /// </summary>
        MaskForm = 106,
    }
}