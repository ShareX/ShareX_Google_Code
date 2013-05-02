#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (C) 2008-2013 ShareX Developers

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelpersLib.Steam
{
    // screenshots.vdf parser
    public class SteamScreenshotsParse
    {
        private Tokenizer tokenizer;
        private List<Token> tokenList;
        private List<Dictionary<string, string>> screenshotList;

        public SteamScreenshotsParse()
        {
            tokenizer = new Tokenizer
            {
                AutoParseLiteral = true,
                KeepWhitespace = false
            };
        }

        public void Parse(string filePath)
        {
            tokenList = tokenizer.TokenizeFile(filePath);
            screenshotList = new List<Dictionary<string, string>>();

            try
            {
                BetweenTagsResult screenshotsResult = Tokenizer.GetBetweenTags(tokenList, "{", "}");

                if (screenshotsResult.Status)
                {
                    int gameIDIndex = 0;

                    while (true)
                    {
                        BetweenTagsResult gameIDResult = Tokenizer.GetBetweenTags(screenshotsResult.TokenList, "{", "}", gameIDIndex);

                        if (gameIDResult.Status)
                        {
                            int screenshotIDIndex = 0;

                            while (true)
                            {
                                BetweenTagsResult screenshotIDResult = Tokenizer.GetBetweenTags(gameIDResult.TokenList, "{", "}", screenshotIDIndex);

                                if (screenshotIDResult.Status)
                                {
                                    Dictionary<string, string> nameValuePairs = new Dictionary<string, string>();

                                    for (int i = 0; i < screenshotIDResult.TokenList.Count; i++)
                                    {
                                        Token currentToken = screenshotIDResult.TokenList[i];
                                        if (currentToken.Type == TokenType.Literal)
                                        {
                                            string name = currentToken.Text;
                                            i++;
                                            currentToken = screenshotIDResult.TokenList[i];
                                            if (currentToken.Type == TokenType.Literal)
                                            {
                                                string value = currentToken.Text;
                                                nameValuePairs.Add(name, value);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                    screenshotList.Add(nameValuePairs);

                                    if (screenshotIDResult.Status && screenshotIDResult.EndIndex < gameIDResult.TokenList.Count)
                                    {
                                        screenshotIDIndex = screenshotIDResult.EndIndex;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }

                            if (gameIDResult.Status && gameIDResult.EndIndex < screenshotsResult.TokenList.Count)
                            {
                                gameIDIndex = gameIDResult.EndIndex;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch { }
        }
    }
}