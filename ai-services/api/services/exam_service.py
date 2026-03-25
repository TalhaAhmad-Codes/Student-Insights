from api.client import ApiClient
from api.routes import Exam

api = ApiClient()


class ExamService:
    @staticmethod
    def get_all():
        return api.get(Exam.Get.all())

    @staticmethod
    def create_bulk(data: list):
        return api.post(Exam.Post.create_bulk(), data)
