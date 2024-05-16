
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                =  0, // (EOF)
        SYMBOL_ERROR              =  1, // (Error)
        SYMBOL_WHITESPACE         =  2, // (Whitespace)
        SYMBOL_MINUS              =  3, // '-'
        SYMBOL_EXCLAMEQ           =  4, // '!='
        SYMBOL_QUOTE              =  5, // '"'
        SYMBOL_QUOTERPARAN        =  6, // '")'
        SYMBOL_LPARAN             =  7, // '('
        SYMBOL_RPARAN             =  8, // ')'
        SYMBOL_RPARANCOLON        =  9, // '): '
        SYMBOL_RPARANLBRACE       = 10, // '){ '
        SYMBOL_TIMES              = 11, // '*'
        SYMBOL_COMMA              = 12, // ','
        SYMBOL_DOT                = 13, // '.'
        SYMBOL_DIV                = 14, // '/'
        SYMBOL__                  = 15, // '_'
        SYMBOL_LBRACE             = 16, // '{'
        SYMBOL_RBRACE             = 17, // '}'
        SYMBOL_RBRACEELSE         = 18, // '}else '
        SYMBOL_RBRACEELSELBRACE   = 19, // '}else { '
        SYMBOL_RBRACEWHILELPARAN  = 20, // '}while('
        SYMBOL_PLUS               = 21, // '+'
        SYMBOL_LT                 = 22, // '<'
        SYMBOL_LTEQ               = 23, // '<='
        SYMBOL_EQ                 = 24, // '='
        SYMBOL_EQEQ               = 25, // '=='
        SYMBOL_GT                 = 26, // '>'
        SYMBOL_GTEQ               = 27, // '>='
        SYMBOL_CASELPARAN         = 28, // 'case('
        SYMBOL_DEFAULTCOLON       = 29, // 'default: '
        SYMBOL_DIGIT              = 30, // digit
        SYMBOL_DOLBRACE           = 31, // 'do{'
        SYMBOL_FALSE              = 32, // False
        SYMBOL_FORLPARAN          = 33, // 'for('
        SYMBOL_FUNCTION           = 34, // function
        SYMBOL_IFLPARAN           = 35, // 'if('
        SYMBOL_LET                = 36, // let
        SYMBOL_LETTER             = 37, // letter
        SYMBOL_PRINTLPARAN        = 38, // 'print('
        SYMBOL_PRINTLPARANQUOTE   = 39, // 'print("'
        SYMBOL_SWITCHLPARAN       = 40, // 'switch('
        SYMBOL_TRUE               = 41, // True
        SYMBOL_WHILELPARAN        = 42, // 'while('
        SYMBOL_ADDEXP             = 43, // <AddExp>
        SYMBOL_ADDEXPPRIME        = 44, // <AddExpPrime>
        SYMBOL_ASSIGNMENTEXP      = 45, // <AssignmentExp>
        SYMBOL_BOOLEAN            = 46, // <Boolean>
        SYMBOL_CASES              = 47, // <Cases>
        SYMBOL_COMPARISONEXP      = 48, // <ComparisonExp>
        SYMBOL_COMPARISONOPERATOR = 49, // <ComparisonOperator>
        SYMBOL_DIGIT2             = 50, // <Digit>
        SYMBOL_EXPRESSION         = 51, // <Expression>
        SYMBOL_FLOAT              = 52, // <Float>
        SYMBOL_FLOATPRIME         = 53, // <FloatPrime>
        SYMBOL_FORSTATEMENT       = 54, // <ForStatement>
        SYMBOL_FUNCTION2          = 55, // <Function>
        SYMBOL_IDENTIFIER         = 56, // <Identifier>
        SYMBOL_IDENTIFIERPRIME    = 57, // <IdentifierPrime>
        SYMBOL_IFSTATEMENT        = 58, // <IfStatement>
        SYMBOL_INTEGER            = 59, // <Integer>
        SYMBOL_INTEGERPRIME       = 60, // <IntegerPrime>
        SYMBOL_LETTER2            = 61, // <Letter>
        SYMBOL_MOREPARAMS         = 62, // <MoreParams>
        SYMBOL_MULTEXP            = 63, // <MultExp>
        SYMBOL_MULTEXPPRIME       = 64, // <MultExpPrime>
        SYMBOL_NEGATEEXP          = 65, // <NegateExp>
        SYMBOL_NUMERICVALUE       = 66, // <NumericValue>
        SYMBOL_PARAMETERS         = 67, // <Parameters>
        SYMBOL_PRINTSTATEMENT     = 68, // <PrintStatement>
        SYMBOL_PROGRAM            = 69, // <Program>
        SYMBOL_STRING             = 70, // <String>
        SYMBOL_STRINGPRIME        = 71, // <StringPrime>
        SYMBOL_SWITCHSTATEMENT    = 72, // <SwitchStatement>
        SYMBOL_VALUE              = 73, // <Value>
        SYMBOL_VAR                = 74, // <Var>
        SYMBOL_WHILESTATEMENT     = 75  // <WhileStatement>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM                                                   =  0, // <Program> ::= <Function> <Program>
        RULE_PROGRAM2                                                  =  1, // <Program> ::= 
        RULE_FUNCTION_FUNCTION_LPARAN_RPARAN_LBRACE_RBRACE             =  2, // <Function> ::= function <Identifier> '(' <Parameters> ')' '{' <Expression> '}'
        RULE_PARAMETERS_LET                                            =  3, // <Parameters> ::= let <Identifier> <MoreParams>
        RULE_PARAMETERS                                                =  4, // <Parameters> ::= 
        RULE_MOREPARAMS_COMMA_LET                                      =  5, // <MoreParams> ::= ',' let <Identifier> <MoreParams>
        RULE_MOREPARAMS                                                =  6, // <MoreParams> ::= 
        RULE_EXPRESSION                                                =  7, // <Expression> ::= <AssignmentExp>
        RULE_EXPRESSION2                                               =  8, // <Expression> ::= <PrintStatement>
        RULE_EXPRESSION3                                               =  9, // <Expression> ::= <ComparisonExp>
        RULE_EXPRESSION4                                               = 10, // <Expression> ::= <WhileStatement>
        RULE_EXPRESSION5                                               = 11, // <Expression> ::= <ForStatement>
        RULE_EXPRESSION6                                               = 12, // <Expression> ::= <IfStatement>
        RULE_EXPRESSION7                                               = 13, // <Expression> ::= <SwitchStatement>
        RULE_EXPRESSION8                                               = 14, // <Expression> ::= <AddExp>
        RULE_ASSIGNMENTEXP_LET_EQ                                      = 15, // <AssignmentExp> ::= let <Identifier> '=' <Var>
        RULE_ASSIGNMENTEXP_EQ                                          = 16, // <AssignmentExp> ::= <Identifier> '=' <Var>
        RULE_PRINTSTATEMENT_PRINTLPARANQUOTE_QUOTERPARAN               = 17, // <PrintStatement> ::= 'print("' <String> '")'
        RULE_PRINTSTATEMENT_PRINTLPARAN_RPARAN                         = 18, // <PrintStatement> ::= 'print(' <Var> ')'
        RULE_COMPARISONEXP                                             = 19, // <ComparisonExp> ::= <Var> <ComparisonOperator> <Value>
        RULE_WHILESTATEMENT_WHILELPARAN_RPARANLBRACE_RBRACE            = 20, // <WhileStatement> ::= 'while(' <Var> <ComparisonOperator> <Var> '){ ' <Expression> '}'
        RULE_WHILESTATEMENT_DOLBRACE_RBRACEWHILELPARAN_RPARAN          = 21, // <WhileStatement> ::= 'do{' <Expression> '}while(' <Var> <ComparisonOperator> <Var> ')'
        RULE_FORSTATEMENT_FORLPARAN_COMMA_COMMA_RPARANLBRACE_RBRACE    = 22, // <ForStatement> ::= 'for(' <AssignmentExp> ',' <Var> <ComparisonOperator> <Value> ',' <AddExp> '){ ' <Expression> '}'
        RULE_IFSTATEMENT_IFLPARAN_RPARANLBRACE_RBRACE                  = 23, // <IfStatement> ::= 'if(' <Var> <ComparisonOperator> <Value> '){ ' <Expression> '}'
        RULE_IFSTATEMENT_IFLPARAN_RPARANLBRACE_RBRACEELSE              = 24, // <IfStatement> ::= 'if(' <Var> <ComparisonOperator> <Value> '){ ' <Expression> '}else ' <IfStatement>
        RULE_IFSTATEMENT_IFLPARAN_RPARANLBRACE_RBRACEELSELBRACE_RBRACE = 25, // <IfStatement> ::= 'if(' <Var> <ComparisonOperator> <Value> '){ ' <Expression> '}else { ' <Expression> '}'
        RULE_SWITCHSTATEMENT_SWITCHLPARAN_RPARANLBRACE_RBRACE          = 26, // <SwitchStatement> ::= 'switch(' <Var> '){ ' <Cases> '}'
        RULE_CASES_CASELPARAN_RPARANCOLON                              = 27, // <Cases> ::= 'case(' <Var> '): ' <Expression> <Cases>
        RULE_CASES_DEFAULTCOLON                                        = 28, // <Cases> ::= 'default: ' <Expression>
        RULE_ADDEXP                                                    = 29, // <AddExp> ::= <MultExp> <AddExpPrime>
        RULE_ADDEXPPRIME_PLUS                                          = 30, // <AddExpPrime> ::= '+' <MultExp> <AddExpPrime>
        RULE_ADDEXPPRIME_MINUS                                         = 31, // <AddExpPrime> ::= '-' <MultExp> <AddExpPrime>
        RULE_ADDEXPPRIME                                               = 32, // <AddExpPrime> ::= 
        RULE_MULTEXP                                                   = 33, // <MultExp> ::= <NegateExp> <MultExpPrime>
        RULE_MULTEXPPRIME_TIMES                                        = 34, // <MultExpPrime> ::= '*' <NegateExp> <MultExpPrime>
        RULE_MULTEXPPRIME_DIV                                          = 35, // <MultExpPrime> ::= '/' <NegateExp> <MultExpPrime>
        RULE_MULTEXPPRIME                                              = 36, // <MultExpPrime> ::= 
        RULE_NEGATEEXP_MINUS                                           = 37, // <NegateExp> ::= '-' <NumericValue>
        RULE_NEGATEEXP                                                 = 38, // <NegateExp> ::= <Value>
        RULE_VAR                                                       = 39, // <Var> ::= <Identifier>
        RULE_VAR2                                                      = 40, // <Var> ::= <Value>
        RULE_COMPARISONOPERATOR_GT                                     = 41, // <ComparisonOperator> ::= '>'
        RULE_COMPARISONOPERATOR_LT                                     = 42, // <ComparisonOperator> ::= '<'
        RULE_COMPARISONOPERATOR_LTEQ                                   = 43, // <ComparisonOperator> ::= '<='
        RULE_COMPARISONOPERATOR_GTEQ                                   = 44, // <ComparisonOperator> ::= '>='
        RULE_COMPARISONOPERATOR_EQEQ                                   = 45, // <ComparisonOperator> ::= '=='
        RULE_COMPARISONOPERATOR_EXCLAMEQ                               = 46, // <ComparisonOperator> ::= '!='
        RULE_NUMERICVALUE                                              = 47, // <NumericValue> ::= <Integer>
        RULE_NUMERICVALUE2                                             = 48, // <NumericValue> ::= <Float>
        RULE_VALUE_QUOTE_QUOTE                                         = 49, // <Value> ::= '"' <String> '"'
        RULE_VALUE                                                     = 50, // <Value> ::= <Integer>
        RULE_VALUE2                                                    = 51, // <Value> ::= <Float>
        RULE_VALUE3                                                    = 52, // <Value> ::= <Boolean>
        RULE_VALUE_LPARAN_RPARAN                                       = 53, // <Value> ::= '(' <Expression> ')'
        RULE_INTEGER                                                   = 54, // <Integer> ::= <Digit> <IntegerPrime>
        RULE_INTEGERPRIME                                              = 55, // <IntegerPrime> ::= <Digit> <IntegerPrime>
        RULE_INTEGERPRIME2                                             = 56, // <IntegerPrime> ::= 
        RULE_FLOAT_DOT                                                 = 57, // <Float> ::= <Digit> <FloatPrime> '.' <Digit> <FloatPrime>
        RULE_FLOATPRIME                                                = 58, // <FloatPrime> ::= <Digit> <FloatPrime>
        RULE_FLOATPRIME2                                               = 59, // <FloatPrime> ::= 
        RULE_BOOLEAN_TRUE                                              = 60, // <Boolean> ::= True
        RULE_BOOLEAN_FALSE                                             = 61, // <Boolean> ::= False
        RULE_IDENTIFIER                                                = 62, // <Identifier> ::= <Letter> <IdentifierPrime>
        RULE_IDENTIFIERPRIME                                           = 63, // <IdentifierPrime> ::= <Letter> <IdentifierPrime>
        RULE_IDENTIFIERPRIME2                                          = 64, // <IdentifierPrime> ::= <Digit> <IdentifierPrime>
        RULE_IDENTIFIERPRIME3                                          = 65, // <IdentifierPrime> ::= 
        RULE_STRING                                                    = 66, // <String> ::= <Letter> <StringPrime>
        RULE_STRINGPRIME                                               = 67, // <StringPrime> ::= <Letter> <StringPrime>
        RULE_STRINGPRIME2                                              = 68, // <StringPrime> ::= <Digit> <StringPrime>
        RULE_STRINGPRIME_MINUS                                         = 69, // <StringPrime> ::= '-' <StringPrime>
        RULE_STRINGPRIME__                                             = 70, // <StringPrime> ::= '_' <StringPrime>
        RULE_DIGIT_DIGIT                                               = 71, // <Digit> ::= digit
        RULE_LETTER_LETTER                                             = 72  // <Letter> ::= letter
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lsterrors;
        public MyParser(string filename, ListBox lsterrors)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open,
                                               FileAccess.Read,
                                               FileShare.Read);

            Init(stream);
            stream.Close();
            this.lsterrors = lsterrors;
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnReduce += new LALRParser.ReduceHandler(ReduceEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
            parser.OnAccept += new LALRParser.AcceptHandler(AcceptEvent);
            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            parser.Parse(source);

        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
                //todo: Report message to UI?
            }
        }

        private Object CreateObject(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //(Whitespace)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_QUOTE :
                //'"'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_QUOTERPARAN :
                //'")'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPARAN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPARAN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPARANCOLON :
                //'): '
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPARANLBRACE :
                //'){ '
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOT :
                //'.'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL__ :
                //'_'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACEELSE :
                //'}else '
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACEELSELBRACE :
                //'}else { '
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACEWHILELPARAN :
                //'}while('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASELPARAN :
                //'case('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULTCOLON :
                //'default: '
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOLBRACE :
                //'do{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FALSE :
                //False
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORLPARAN :
                //'for('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION :
                //function
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFLPARAN :
                //'if('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LET :
                //let
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LETTER :
                //letter
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINTLPARAN :
                //'print('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINTLPARANQUOTE :
                //'print("'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHLPARAN :
                //'switch('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRUE :
                //True
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILELPARAN :
                //'while('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADDEXP :
                //<AddExp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADDEXPPRIME :
                //<AddExpPrime>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENTEXP :
                //<AssignmentExp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOLEAN :
                //<Boolean>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASES :
                //<Cases>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMPARISONEXP :
                //<ComparisonExp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMPARISONOPERATOR :
                //<ComparisonOperator>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<Digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //<Float>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOATPRIME :
                //<FloatPrime>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORSTATEMENT :
                //<ForStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION2 :
                //<Function>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //<Identifier>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIERPRIME :
                //<IdentifierPrime>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFSTATEMENT :
                //<IfStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGER :
                //<Integer>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGERPRIME :
                //<IntegerPrime>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LETTER2 :
                //<Letter>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MOREPARAMS :
                //<MoreParams>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULTEXP :
                //<MultExp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULTEXPPRIME :
                //<MultExpPrime>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEGATEEXP :
                //<NegateExp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUMERICVALUE :
                //<NumericValue>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETERS :
                //<Parameters>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINTSTATEMENT :
                //<PrintStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //<String>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGPRIME :
                //<StringPrime>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHSTATEMENT :
                //<SwitchStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<Value>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VAR :
                //<Var>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILESTATEMENT :
                //<WhileStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        private void ReduceEvent(LALRParser parser, ReduceEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
                //todo: Report message to UI?
            }
        }

        public static Object CreateObject(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM :
                //<Program> ::= <Function> <Program>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PROGRAM2 :
                //<Program> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_FUNCTION_LPARAN_RPARAN_LBRACE_RBRACE :
                //<Function> ::= function <Identifier> '(' <Parameters> ')' '{' <Expression> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS_LET :
                //<Parameters> ::= let <Identifier> <MoreParams>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS :
                //<Parameters> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MOREPARAMS_COMMA_LET :
                //<MoreParams> ::= ',' let <Identifier> <MoreParams>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MOREPARAMS :
                //<MoreParams> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <AssignmentExp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION2 :
                //<Expression> ::= <PrintStatement>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION3 :
                //<Expression> ::= <ComparisonExp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION4 :
                //<Expression> ::= <WhileStatement>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION5 :
                //<Expression> ::= <ForStatement>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION6 :
                //<Expression> ::= <IfStatement>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION7 :
                //<Expression> ::= <SwitchStatement>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION8 :
                //<Expression> ::= <AddExp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENTEXP_LET_EQ :
                //<AssignmentExp> ::= let <Identifier> '=' <Var>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENTEXP_EQ :
                //<AssignmentExp> ::= <Identifier> '=' <Var>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PRINTSTATEMENT_PRINTLPARANQUOTE_QUOTERPARAN :
                //<PrintStatement> ::= 'print("' <String> '")'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PRINTSTATEMENT_PRINTLPARAN_RPARAN :
                //<PrintStatement> ::= 'print(' <Var> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMPARISONEXP :
                //<ComparisonExp> ::= <Var> <ComparisonOperator> <Value>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_WHILESTATEMENT_WHILELPARAN_RPARANLBRACE_RBRACE :
                //<WhileStatement> ::= 'while(' <Var> <ComparisonOperator> <Var> '){ ' <Expression> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_WHILESTATEMENT_DOLBRACE_RBRACEWHILELPARAN_RPARAN :
                //<WhileStatement> ::= 'do{' <Expression> '}while(' <Var> <ComparisonOperator> <Var> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORSTATEMENT_FORLPARAN_COMMA_COMMA_RPARANLBRACE_RBRACE :
                //<ForStatement> ::= 'for(' <AssignmentExp> ',' <Var> <ComparisonOperator> <Value> ',' <AddExp> '){ ' <Expression> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_IFSTATEMENT_IFLPARAN_RPARANLBRACE_RBRACE :
                //<IfStatement> ::= 'if(' <Var> <ComparisonOperator> <Value> '){ ' <Expression> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_IFSTATEMENT_IFLPARAN_RPARANLBRACE_RBRACEELSE :
                //<IfStatement> ::= 'if(' <Var> <ComparisonOperator> <Value> '){ ' <Expression> '}else ' <IfStatement>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_IFSTATEMENT_IFLPARAN_RPARANLBRACE_RBRACEELSELBRACE_RBRACE :
                //<IfStatement> ::= 'if(' <Var> <ComparisonOperator> <Value> '){ ' <Expression> '}else { ' <Expression> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHSTATEMENT_SWITCHLPARAN_RPARANLBRACE_RBRACE :
                //<SwitchStatement> ::= 'switch(' <Var> '){ ' <Cases> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CASES_CASELPARAN_RPARANCOLON :
                //<Cases> ::= 'case(' <Var> '): ' <Expression> <Cases>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CASES_DEFAULTCOLON :
                //<Cases> ::= 'default: ' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ADDEXP :
                //<AddExp> ::= <MultExp> <AddExpPrime>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ADDEXPPRIME_PLUS :
                //<AddExpPrime> ::= '+' <MultExp> <AddExpPrime>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ADDEXPPRIME_MINUS :
                //<AddExpPrime> ::= '-' <MultExp> <AddExpPrime>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ADDEXPPRIME :
                //<AddExpPrime> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MULTEXP :
                //<MultExp> ::= <NegateExp> <MultExpPrime>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MULTEXPPRIME_TIMES :
                //<MultExpPrime> ::= '*' <NegateExp> <MultExpPrime>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MULTEXPPRIME_DIV :
                //<MultExpPrime> ::= '/' <NegateExp> <MultExpPrime>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MULTEXPPRIME :
                //<MultExpPrime> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP_MINUS :
                //<NegateExp> ::= '-' <NumericValue>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP :
                //<NegateExp> ::= <Value>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VAR :
                //<Var> ::= <Identifier>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VAR2 :
                //<Var> ::= <Value>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMPARISONOPERATOR_GT :
                //<ComparisonOperator> ::= '>'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMPARISONOPERATOR_LT :
                //<ComparisonOperator> ::= '<'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMPARISONOPERATOR_LTEQ :
                //<ComparisonOperator> ::= '<='
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMPARISONOPERATOR_GTEQ :
                //<ComparisonOperator> ::= '>='
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMPARISONOPERATOR_EQEQ :
                //<ComparisonOperator> ::= '=='
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMPARISONOPERATOR_EXCLAMEQ :
                //<ComparisonOperator> ::= '!='
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NUMERICVALUE :
                //<NumericValue> ::= <Integer>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NUMERICVALUE2 :
                //<NumericValue> ::= <Float>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VALUE_QUOTE_QUOTE :
                //<Value> ::= '"' <String> '"'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VALUE :
                //<Value> ::= <Integer>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VALUE2 :
                //<Value> ::= <Float>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VALUE3 :
                //<Value> ::= <Boolean>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VALUE_LPARAN_RPARAN :
                //<Value> ::= '(' <Expression> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTEGER :
                //<Integer> ::= <Digit> <IntegerPrime>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTEGERPRIME :
                //<IntegerPrime> ::= <Digit> <IntegerPrime>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTEGERPRIME2 :
                //<IntegerPrime> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FLOAT_DOT :
                //<Float> ::= <Digit> <FloatPrime> '.' <Digit> <FloatPrime>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FLOATPRIME :
                //<FloatPrime> ::= <Digit> <FloatPrime>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FLOATPRIME2 :
                //<FloatPrime> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_BOOLEAN_TRUE :
                //<Boolean> ::= True
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_BOOLEAN_FALSE :
                //<Boolean> ::= False
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_IDENTIFIER :
                //<Identifier> ::= <Letter> <IdentifierPrime>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_IDENTIFIERPRIME :
                //<IdentifierPrime> ::= <Letter> <IdentifierPrime>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_IDENTIFIERPRIME2 :
                //<IdentifierPrime> ::= <Digit> <IdentifierPrime>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_IDENTIFIERPRIME3 :
                //<IdentifierPrime> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STRING :
                //<String> ::= <Letter> <StringPrime>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STRINGPRIME :
                //<StringPrime> ::= <Letter> <StringPrime>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STRINGPRIME2 :
                //<StringPrime> ::= <Digit> <StringPrime>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STRINGPRIME_MINUS :
                //<StringPrime> ::= '-' <StringPrime>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STRINGPRIME__ :
                //<StringPrime> ::= '_' <StringPrime>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<Digit> ::= digit
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LETTER_LETTER :
                //<Letter> ::= letter
                //todo: Create a new object using the stored user objects.
                return null;

            }
            throw new RuleException("Unknown rule");
        }
        private void AcceptEvent(LALRParser parser, AcceptEventArgs args)
        {
            //todo: Use your fully reduced args.Token.UserObject
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '" + args.Token.ToString() + "'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string errormsg = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + "' in line: " + args.UnexpectedToken.Location.LineNr;
            lsterrors.Items.Add(errormsg);

            string message = "Expected token: '" + args.ExpectedTokens.ToString() + "'";
            lsterrors.Items.Add(message);


            //todo: Report message to UI?
        }


    }
}