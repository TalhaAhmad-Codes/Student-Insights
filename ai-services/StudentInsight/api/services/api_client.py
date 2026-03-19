from api.routes import BASE_URL
import requests

class ApiClient:
    
    ###########################
    # GET
    ###########################
    def get(self, endpoint: str, params=None):
        res = requests.get(f"{BASE_URL}{endpoint}", params=params)
        self._handle_response(res)
        return res.json()

    ###########################
    # POST
    ###########################
    def post(self, endpoint: str, data=None):
        res = requests.post(f"{BASE_URL}{endpoint}", json=data)
        self._handle_response(res)
        return res.json()

    ###########################
    # PUT
    ###########################
    def put(self, endpoint: str, data=None):
        res = requests.put(f"{BASE_URL}{endpoint}", json=data)
        self._handle_response(res)
        return res.json()

    ###########################
    # PATCH
    ###########################
    def patch(self, endpoint: str, data=None):
        res = requests.patch(f"{BASE_URL}{endpoint}", json=data)
        self._handle_response(res)
        return res.json()

    ###########################
    # DELETE
    ###########################
    def delete(self, endpoint: str):
        res = requests.delete(f"{BASE_URL}{endpoint}")
        self._handle_response(res)
        return res.status_code == 204

    ###########################
    # Error Handling
    ###########################
    def _handle_response(self, response):
        if not response.ok:
            raise Exception(
                f"API Error!\nCode:\t{response.status_code}\nMessage:\t{response.text}"
            )
