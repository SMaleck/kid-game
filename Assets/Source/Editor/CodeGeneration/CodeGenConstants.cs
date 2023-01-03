using Game.Utility;

namespace Source.Editor.CodeGeneration
{
    public static class CodeGenConstants
    {
        public const string CodeGenMenu = ProjectConst.MenuRoot + "CodeGen/";
        public const string CodeGenWarning = "// This file is GENERATED! Changes might get lost.";

        // ------------------------ Replaceable Placeholders
        public const string CODEGEN_WARNING = "%CODEGEN_WARNING%";
    }
}
