import * as api from './api.js';


export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAllPosts() {
    return await api.get('/data/posts?sortBy=_createdOn%20desc');
}

export async function getPostById(id) {
    return await api.get('/data/posts/' + id);
}

export async function getAllPostsByUser(id) {
    return await api.get(`/data/posts?where=_ownerId%3D%22${id}%22&sortBy=_createdOn%20desc`);
}

export async function deletePostById(id) {
    return api.del('/data/posts/' + id);
}

export async function hasDonated(postId, userId) {
    return api.get(`/data/donations?where=postId%3D%22${postId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}

export async function getDonationCount(postId) {
    return api.get(`/data/donations?where=postId%3D%22${postId}%22&distinct=_ownerId&count`);
}

export async function donate(postId) {
    return api.post('/data/donations', { postId });
}