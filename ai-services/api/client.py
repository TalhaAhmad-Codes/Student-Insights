from api.routes import BASE_URL
import requests


class ApiClient:
    def __init__(self):
        self.base_url = BASE_URL

    def _url(self, endpoint: str):
        return f"{self.base_url}{endpoint}"

    def _handle(self, res):
        if not res.ok:
            raise Exception(f"API Error {res.status_code}: {res.text}")

    def _serialize(self, obj):
        if obj is None:
            return None

        if hasattr(obj, "to_dict"):
            return obj.to_dict()

        return obj

    def get(self, endpoint: str, filter = None):
        params = self._serialize(filter)
        res = requests.get(self._url(endpoint), params=params)
        self._handle(res)
        return res.json()

    def post(self, endpoint: str, data):
        data = self._serialize(data)
        res = requests.post(self._url(endpoint), json=data)
        self._handle(res)
        return res.json()

    def put(self, endpoint: str, data):
        data = self._serialize(data)
        res = requests.put(self._url(endpoint), json=data)
        self._handle(res)
        return res.json()

    def patch(self, endpoint: str, data):
        data = self._serialize(data)
        res = requests.patch(self._url(endpoint), json=data)
        self._handle(res)
        return res.json()

    def delete(self, endpoint: str):
        res = requests.delete(self._url(endpoint))
        self._handle(res)
        return res.status_code == 204
