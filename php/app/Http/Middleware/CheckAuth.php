<?php

namespace App\Http\Middleware;

use App\Models\User;
use Closure;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Support\Facades\Auth;
use Spatie\Permission\Models\Permission;
use Spatie\Permission\Models\Role;

class CheckAuth
{
    /**
     * Handle an incoming request.
     *
     * @param \Illuminate\Http\Request $request
     * @param \Closure $next
     * @param $permissions
     * @return mixed
     * @throws \Exception
     */
    public function handle($request, Closure $next, $permissions)
    {
        /** @var User $user */
        $user = Auth::user();

        if(!isset($user))
            return redirect()->route("home");

        if($user->hasAnyPermission($permissions)) {
            return $next($request);
        }

        return redirect()->route("home");
    }
}
