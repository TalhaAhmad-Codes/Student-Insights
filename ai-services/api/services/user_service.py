from api.client import ApiClient
from api.routes import User

api = ApiClient()


class UserService:
    @staticmethod
    def get_all():
        return api.get(User.Get.all())

    @staticmethod
    def create_bulk(data: list):
        return api.post(User.Post.create_bulk(), data)
