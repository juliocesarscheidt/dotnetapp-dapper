namespace Api.Application.Dto
{
    public class HttpResponseDto
    {
        public object data { get; set; }

        public object metadata { get; set; }

        public int status_code { get; set; }

        public HttpResponseDto() {
        }

        public HttpResponseDto(object data, object metadata, int status_code) {
            this.data = data;
            this.metadata = metadata;
            this.status_code = status_code;
        }

        public HttpResponseDto setData(object data) {
            this.data = data;
            return this;
        }

        public HttpResponseDto setMetadata(object metadata) {
            this.metadata = metadata;
            return this;
        }

        public HttpResponseDto setStatusCode(int status_code) {
            this.status_code = status_code;
            return this;
        }
    }
}
