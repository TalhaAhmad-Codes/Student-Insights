from api.client import ApiClient
from api.routes import Student

api = ApiClient()


class StudentService:
    @staticmethod
    def get_all():
        return api.get(Student.Get.all())

    @staticmethod
    def create_bulk(data: list):
        return api.post(Student.Post.create_bulk(), data)
