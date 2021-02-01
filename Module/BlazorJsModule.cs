using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Wietility.Module { 

    public class BlazorJsModule
    {
        private readonly IJSRuntime JsRuntime;

        public BlazorJsModule(IJSRuntime js)
        {
            this.JsRuntime = js;
        }

        public async Task<T> CallJavascriptFunction<T>(string funcNm, Array arguments = null)
        {
            return await JsRuntime.InvokeAsync<T>(funcNm, arguments);
        }

        public async Task CallJavascriptVoidFunctionAsync(string funcNm, Array arguments = null)
        {
            await JsRuntime.InvokeVoidAsync(funcNm, arguments);
        }

        public void CallJavaScriptVoidFunction(string funcNm, Array arguments = null)
        {
            ((IJSInProcessRuntime)JsRuntime).InvokeVoid(funcNm, arguments);
        }
    }
}
