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

#region License Information (MIT)

/*
The MIT License (MIT)

Copyright (c) 2013 Gregoire Pailler

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

#endregion

using System;

namespace CG.Web.MegaApiClient
{
    public class ApiException : Exception
    {
        internal ApiException(ApiResultCode apiResultCode)
        {
            this.ApiResultCode = apiResultCode;
        }

        public ApiResultCode ApiResultCode { get; private set; }

        public override string Message
        {
            get { return string.Format("API response: {0}", this.ApiResultCode); }
        }
    }

    public class DownloadException : Exception
    {
        public DownloadException()
            : base("Invalid file checksum")
        {
        }
    }

    public enum ApiResultCode
    {
        Ok = 0,
        InternalError = -1,
        BadArguments = -2,
        RequestFailedRetry = -3,
        TooManyRequests = -4,
        RequestFailedPermanetly = -5,
        ToManyRequestsForThisResource = -6,
        ResourceAccessOutOfRange = -7,
        ResourceExpired = -8,
        ResourceNotExists = -9,
        CircularLinkage = -10,
        AccessDenied = -11,
        ResourceAlreadyExists = -12,
        RequestIncomplete = -13,
        CryptographicError = -14,
        BadSessionId = -15,
        ResourceAdministrativelyBlocked = -16,
        QuotaExceeded = -17,
        ResourceTemporarilyNotAvailable = -18,
        TooManyConnectionsOnThisResource = -19,
        FileCouldNotBeWrittenTo = -20,
        FileCouldNotBeReadFrom = -21,
        InvalidOrMissingApplicationKey = -22
    }
}
