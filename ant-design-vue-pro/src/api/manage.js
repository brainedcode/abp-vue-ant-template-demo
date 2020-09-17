import request from '@/utils/request'

const api = {
  user: '/user',
  role: '/api/identity/roles',
  createRole: '/api/identity/roles',
  service: '/service',
  permission: '/permission',
  permissionNoPager: '/permission/no-pager',
  orgTree: '/org/tree',
  profile: '/identity/my-profile'
}

export default api

export function getProfile () {
  return request({
    url: api.profile,
    method: 'get'
  })
}

export function getUserList (parameter) {
  return request({
    url: api.user,
    method: 'get',
    params: parameter
  })
}

export function getRoleList (parameter) {
  return request({
    url: api.role,
    method: 'get',
    params: parameter
  })
}
export function createRole (parameter) {
  return request({
    url: api.role,
    method: 'post',
    data: parameter
  })
}
export function updateRole (id, parameter) {
  return request({
    url: api.role + '/' + id,
    method: 'put',
    data: parameter
  })
}
export function deleteRole (id) {
  return request({
    url: api.role + '/' + id,
    method: 'delete'
  })
}
export function getServiceList (parameter) {
  return request({
    url: api.service,
    method: 'get',
    params: parameter
  })
}

export function getPermissions (parameter) {
  return request({
    url: api.permissionNoPager,
    method: 'get',
    params: parameter
  })
}

export function getOrgTree (parameter) {
  return request({
    url: api.orgTree,
    method: 'get',
    params: parameter
  })
}

// id == 0 add     post
// id != 0 update  put
export function saveService (parameter) {
  return request({
    url: api.service,
    method: parameter.id === 0 ? 'post' : 'put',
    data: parameter
  })
}

export function saveSub (sub) {
  return request({
    url: '/sub',
    method: sub.id === 0 ? 'post' : 'put',
    data: sub
  })
}
