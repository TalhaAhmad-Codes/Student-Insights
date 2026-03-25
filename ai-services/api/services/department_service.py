from api.client import ApiClient
from api.routes import Department

api = ApiClient()

class DepartmentService:
    @staticmethod
    def get_all():
        """ Get all departments """
        return api.get(Department.Get.all())

    @staticmethod
    def create_bulk(data: list):
        """ Create bulk department """
        return api.post(Department.Post.create_bulk(), data)
