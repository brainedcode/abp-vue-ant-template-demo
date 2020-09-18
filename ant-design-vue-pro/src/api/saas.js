import request from '@/utils/request'

const api = {
    editions: '/api/saas/editions'
}

export default api

export function getEditionList (parameter) {
    return request({
        url: api.editions,
        method: 'get',
        params: parameter
      })
}

export function createEdition (parameter) {
    return request({
        url: api.editions,
        method: 'post',
        data: parameter
      })
}

export function updateEdition (id, parameter) {
    return request({
        url: api.editions + '/' + id,
        method: 'put',
        data: parameter
      })
}

export function deleteEdition (id) {
    return request({
        url: api.editions + '/' + id,
        method: 'delete'
      })
}
